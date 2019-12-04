using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class KVProtocolInterpreter
{
	private List<Team> teams;
	private FutureScene updatedScene;
	private StreamWriter writer;

	public KVProtocolInterpreter(List<Karaoke.Team> teams, FutureScene scene) {
		this.teams = teams;
		this.updatedScene = scene;
	}

	private void InterpretCommand(params string[] values, StreamWriter writer) {
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
				int value = Int32.Parse(values[1]);
				updatedScene.lightId = value;
				break;
			case "set_color":
				value = Int32.Parse(values[1]);
				updatedScene.color = value;
				break;
			case "continue_show":
				value = Int32.Parse(values[1]);
				updatedScene.continueShow = value > 0;
				break;
			case "set_camera":
				value = Int32.Parse(values[1]);
				updatedScene.cameraId = value;
				break;
			case "clear_competents":
				teams.Clear();
				break;
			case "get_teams":
				GetTeams();
				break;

			default:
				break;
		}

	}
	private void ReturnTeams() {
		string full = "";
		foreach (Team team in teams) {
			full += "add_team," + team.Contestants[0] + "," + team.Contestants[1]+";";
		}
	}
}

