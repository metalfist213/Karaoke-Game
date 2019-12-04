using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class WebServer : MonoBehaviour
{
	public string ip;
	public int port;
	private Thread listenerThread;
	private KVProtocolInterpreter interpreter;
	private GameObject camera;
	// Start is called before the first frame update
	void Start() {
		camera = GameObject.Find("Camera");
		StartCoroutine("StartServer");
	}

	private TcpListener server;
	private bool stop;
	IEnumerator StartServer() {
		IPAddress addr = IPAddress.Parse(ip);
		server = new TcpListener(addr, port);
		teams = new List<Team>();

		// Start listening for client requests.
		Debug.Log("Starting Server..\t" + addr + ":" + port);
		server.Start();
		listenerThread = new Thread(Listener);
		listenerThread.Start();


		yield return null;
	}
	private void Update() {
		if (interpreter == null) return;
		if(interpreter.hasChanged) {
			foreach (LightRotater rot in GameObject.FindObjectsOfType<LightRotater>()) {
				rot.lightColor = interpreter.currentColor;
			}
			if (interpreter.nextCamRoute != null) {
				GameObject.FindObjectOfType<GetPath>().PlayPath(camera, interpreter.nextCamRoute[1], int.Parse(interpreter.nextCamRoute[2]), int.Parse(interpreter.nextCamRoute[3]) > 0);
				interpreter.nextCamRoute = null;
			}
			if (interpreter.nextSfx != null) {
				GameObject.FindObjectOfType<MultiSoundPlayer>().PlayTrack(interpreter.nextSfx, 0.02f);
				interpreter.nextSfx = null;
			}
			if (interpreter.nextAudience != null) {
				GetNextScene().audienceType = interpreter.nextAudience;
				Debug.Log(GetNextScene().audienceType);
				interpreter.nextAudience = null;
			}
			interpreter.hasChanged = false;
		}
	}

	private void OnDestroy() {
		stop = true;
		server.Stop();
		listenerThread.Abort();
	}

	public void Listener() {
		Debug.Log("Listening..");
		interpreter = new KVProtocolInterpreter(teams, updatedScene, camera);
		try {
			while (!stop) {
				TcpClient client = server.AcceptTcpClient();
				Debug.Log("Accepted Client: " + client);
				//str.Write(res, 0, res.Length);
				//str.Flush();

				using (NetworkStream str = client.GetStream()) {

					Debug.Log("Interpreting..");
					using (BinaryReader reader = new BinaryReader(str)) {
						foreach (string split in reader.ReadString().Split(';')) {
							interpreter.InterpretCommand(split.Split(','));
						}
						
						using (BinaryWriter writer = new BinaryWriter(str)) {
							Debug.Log("Responding..");
							writer.Write(interpreter.GetResponseBuffer());
						}
					}
				}
			}
		} catch (Exception e) {
			Debug.LogError(e);
			Listener();
		}
	}

	[SerializeField]
	private List<Team> teams;
	[SerializeField]
	private FutureScene updatedScene;

	public void RegisterTeams(List<Team> teams) {
		this.teams = teams;
	}
	public List<Team> GetTeams() {
		return teams;
	}

	public Team GetNextTeam() {
		foreach (Team team in teams) {
			if (team.HasPlayed) continue;
			return team;
		}
		return null;
	}

	public bool HasNextTeam() {
		return GetNextTeam() != null;
	}
	public FutureScene GetNextScene() {
		return updatedScene;
	}

	public Team GetWinners() {
		Team team = GetTeams()[0];
		foreach(Team t in teams) {
			if(t.GetTotalScore()>=team.GetTotalScore()) {
				team = t;
			}
		}

		return team;
	}
}


[Serializable]
public class FutureScene
{
	public int cameraId;
	public int lightId;
	public int color;
	public string audienceType = "looking";
	public bool continueShow;
	public FutureScene() {

	}
}

[Serializable]
public class Team
{
	[SerializeField]
	private bool hasPlayed;
	[SerializeField]
	private String[] contestants;
	[SerializeField]
	public int audienceScore;
	[SerializeField]
	public int singstarScore;

	public Team() {
		contestants = new string[2];
	}
	public Team(string name1, string name2) {
		contestants = new string[2];
		SetContestants(name1, name2);
	}
	public int GetTotalScore() {
		return audienceScore + singstarScore;
	}
	public void SetContestants(string name1, string name2) {
		contestants[0] = name1;
		contestants[1] = name2;
	}

	public bool HasPlayed { get => hasPlayed; set => hasPlayed = value; }
	public String[] Contestants { get => contestants; set => contestants = value; }
}