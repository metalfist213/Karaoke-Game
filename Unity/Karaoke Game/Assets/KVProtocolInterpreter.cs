using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class KVProtocolInterpreter
{
	private List<Team> teams;
	private FutureScene updatedScene;
	private GameObject camera;
	private StreamWriter writer;
	private string responseBuffer ="";
	public Color currentColor;
	public bool hasChanged = false;
	public string[] nextCamRoute;
	public string nextSfx;
	public string nextAudience;

	public KVProtocolInterpreter(List<Team> teams, FutureScene scene, GameObject camera) {
		this.teams = teams;
		this.updatedScene = scene;
		this.camera = camera;
	}

	public void InterpretCommand(params string[] values) {
		int value;
		Debug.Log("Command: " + values[0]);
		switch (values[0]) {
			case "add_team":
				Team team = new Team(values[1], values[2]);
				teams.Add(team);
				break;
			case "remove_team":
				int index = Int32.Parse(values[1]);
				if (teams.Count > index) teams.RemoveAt(index);
				break;
			case "set_lights":
				value = Int32.Parse(values[1]);
				updatedScene.color = value;


				break;
			case "set_color":

				float r =float.Parse(values[1]);
				float g =float.Parse(values[2]);
				float b =float.Parse(values[3]);
				currentColor = new Color(r, g, b);

				break;
			case "continue_show":
				value = Int32.Parse(values[1]);
				updatedScene.continueShow = value > 0;
				break;
			case "set_camera":
				nextCamRoute = values;
				break;
			case "clear_competents":
				teams.Clear();
				break;
			case "get_teams":
				ReturnTeams();
				break;
			case "set_audience":
				nextAudience = values[1];
				break;
			case "set_track":
				nextSfx = values[1];
				break;
			case "set_score":
				Team t = teams.Find(x=>!x.HasPlayed);
				t.singstarScore = int.Parse(values[1]);
				t.audienceScore = int.Parse(values[2]);

				break;

			default:
				break;
		}
		hasChanged = true;
	}

	public void SetStreamWriter(StreamWriter writer) {
		this.writer = writer;
	}


	private void ReturnTeams() {
		foreach (Team team in teams) {
			responseBuffer += "add_team," + team.Contestants[0] + "," + team.Contestants[1] + ";";
		}
	}

	public string GetResponseBuffer() {
		string res = responseBuffer;
		responseBuffer = "";
		return res;
	}
}

