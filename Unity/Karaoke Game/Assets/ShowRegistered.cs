using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRegistered : MonoBehaviour
{
	private WebServer server;
	private Text text;
	private int lastCount;
    void Start()
    {
		server = GameObject.FindObjectOfType<WebServer>();
		text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lastCount != server.GetTeams().Count) {
			text.text = "";
			int count = 1;
			foreach(Team team in server.GetTeams()) {
				text.text += (count++)+" - " + team.Contestants[0] + " and " + team.Contestants[1]+"\n";
			}
		}

		lastCount = server.GetTeams().Count;
    }
}
