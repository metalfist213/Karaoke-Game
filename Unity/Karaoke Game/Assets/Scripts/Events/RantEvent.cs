using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Events
{
	public class RantEvent : KaraokeEventCollection
	{
		private Team thisTeam;
		private static string[] buzzwordScores = {"Bad", "Decent Show", "Remarkable Show" };
		private static string[] audienceScores = { "The Audience ok", "The Audience liked it", "The Audience Loved it" };
		private static string[] buzzFollowUp = { "Tear to the eye", "Dominator Diss", "Pretty good", "Dab", "Almost as good" };
		public RantEvent(GameObject buzzword, GameObject camera, GameObject audience) : base(buzzword, camera, audience) {
			thisTeam = GameObject.Find("Server").GetComponent<WebServer>().GetNextTeam();
			this.requiresContinue = true;
			AddEvent(() => {
				Audience.GetComponent<MultiSoundPlayer>().PlayTrack("Applause", .02f);
			}, 1, 0);
			AddEvent(BuzzwordRant, 3, 12);
		}

		private void BuzzwordRant() {
			System.Random r = new System.Random();
			int followup = r.Next(0, 4);
			Buzzword.GetComponent<PlayVideo>().EnqueueAllScenes(buzzwordScores[GetReactionType(thisTeam.singstarScore)], audienceScores[GetReactionType(thisTeam.audienceScore)], buzzFollowUp[followup]);
		}

		private int GetReactionType(int score) {
			if(score >= 3000 && score < 6000) {
				return 1;
			} else if(score < 3000) {
				return 0;
			} else {
				return 2;
			}
		}

		public override void BeforeStart() {
			GameObject.FindObjectOfType<GetPath>().PlayPath(Buzzword, "walkToScene", 2, true);
			GameObject.FindObjectOfType<GetPath>().PlayPath(GameObject.Find("PlayerHolder"), "playerWalkToScene", 0, true);

		}

		public override void BeforeNext() {
			thisTeam.HasPlayed = true;

			if (GameObject.Find("Server").GetComponent<WebServer>().HasNextTeam() != false) {
				GameObject.FindObjectOfType<EventController>().EnqueueEvent(new SingEvent(Buzzword, Camera, Audience));
			} else {
				GameObject.FindObjectOfType<EventController>().EnqueueEvent(new EndEvent(Buzzword, Camera, Audience));
			}
		}
	}
}
