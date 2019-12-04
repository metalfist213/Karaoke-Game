using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTest
{
	public partial class Controller : Form
	{
		private string[] cams = { "Front Stage]set_camera,sceneCloseup,0,",
									"Front Stage Further]set_camera,sceneFurther,0,",
									"Audience Stroll]set_camera,AudienceStroll,0,",
									"Overhead Stroll]set_camera,camToScene,0,",
									"Camera Circulation]set_camera,cameraCirculation,0,"};
		private string[] audience_commands = {"Dabbing]set_audience,dabbing",
												"Clapping]set_audience,clapping",
												"Looking]set_audience,looking",
												"Raising]set_audience,raising",
												"Waving]set_audience,waving"
												};
		private string[] sfx = {"Applause]set_track,Applause",
								"Title Melody]set_track,Title Melody",
								};
		public Controller() {
			InitializeComponent();
			continueShow.Enabled = false;
			colorDialog1.AllowFullOpen = true;
			colorDialog1.FullOpen = true;

			PrepareButtons(cams);
			PrepareButtons(audience_commands);
			PrepareButtons(sfx);

			TeamRegistration r = new TeamRegistration();

			Thread t = new Thread(()=>{Application.Run(r); });
			t.Start();
		}

		private void PrepareButtons(string[] commands) {
			foreach (string cs in commands) {
				string name = cs.Split(']')[0];
				string command = cs.Split(']')[1];

				Button b = new Button();
				b.Tag = command;
				string commandType = command.Split(',')[0];
				switch(commandType) {
					case "set_track":
						b.Click += (o, a) => Entry.Connect(Entry.ip, OnOtherCommandPressed((Button)o));
						b.BackColor = Color.Green;
						break;
					case "set_audience":
						b.Click += (o, a) => Entry.Connect(Entry.ip, OnOtherCommandPressed((Button)o));
						b.BackColor = Color.Blue;
						break;

					default:
						b.Click += (o, a) => Entry.Connect(Entry.ip, OnCamChanged((Button)o));
						break;
				}

				b.Width = 100;
				b.Text = name;

				camera.Controls.Add(b);
			}
		}

		private string OnOtherCommandPressed(Button o) {
			return (string)o.Tag;
		}

		private string OnCamChanged(Button o) {
			return (string)o.Tag + (flowingCamera.Checked ? 0 : 1);
		}

		private void Label2_Click(object sender, EventArgs e) {

		}

		private void ContinueShow_Click(object sender, EventArgs e) {
			continueShow.Enabled = false;
			continueShowTick.Checked = false;
			string extraString = "";
			if (audienceScore.Text != "" && singstarScore.Text != "") {
				extraString = "set_score," + audienceScore.Text + "," + singstarScore.Text;
				audienceScore.Text = "";
				singstarScore.Text = "";
			}

			Entry.Connect(Entry.ip, "continue_show,1;" + extraString);
		}

		private void ContinueShowTick_CheckedChanged(object sender, EventArgs e) {
			continueShow.Enabled = continueShowTick.Checked;
		}

		private void SetLightColor_Click(object sender, EventArgs e) {


			DialogResult res = colorDialog1.ShowDialog();

			if (res == DialogResult.OK) {
				Color c =colorDialog1.Color;
				float r =(c.R+0f) / 255;
				float g =(c.G+0f) / 255;
				float b =(c.B+0f) / 255;


				Entry.Connect(Entry.ip, "set_color," + r + "," + g + "," + b);
			}

		}
	}
}
