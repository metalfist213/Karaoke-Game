using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTest
{
	public partial class TeamRegistration : Form
	{
		public TeamRegistration() {
			InitializeComponent();
			UpdateContestantsList(Entry.Connect(Entry.ip, "get_teams"));
		}

		private void AddContestant_Click(object sender, EventArgs e) {
			if(contestant1.Text !="" && contestant2.Text != "") {
				Entry.Connect(Entry.ip, "add_team," + contestant1.Text + "," + contestant2.Text);
				string newTeams = Entry.Connect(Entry.ip, "get_teams");
				UpdateContestantsList(newTeams);

				contestant1.Text = "";
				contestant2.Text = "";
			}
		}

		private void UpdateContestantsList(string str) {
			int count = 1;
			contestantsList.Controls.Clear();
			foreach (string team in str.Split(';')) {
				if (team == "") continue;
				string[] values = team.Split(',');

				Button l = new Button();
				l.Text = (count++) +" - "+ values[1] + " and " + values[2];

				l.Click += (s, e) => OnClick((Button)s);
				l.Width = 100;

				contestantsList.Controls.Add(l);
			}
		}

		private void OnClick(Button b) {
			Entry.Connect(Entry.ip, "remove_team,"+(int.Parse(b.Text.Split(' ')[0])-1));
			string newTeams = Entry.Connect(Entry.ip, "get_teams");
			UpdateContestantsList(newTeams);
		}

	}
}
