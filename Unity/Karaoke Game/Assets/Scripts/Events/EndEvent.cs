using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Events
{
	public class EndEvent : KaraokeEventCollection
	{
		private Team team;
		public EndEvent(GameObject buzzword, GameObject camera, GameObject audience) : base(buzzword, camera, audience) {
			team = GameObject.Find("Server").GetComponent<WebServer>().GetWinners();
			this.requiresContinue = true;
			AddEvent(() => {
				Audience.GetComponent<MultiSoundPlayer>().PlayTrack("Applause", .02f);
			}, 1, 0);
			AddEvent(BuzzEnd, 3, 12);
			AddEvent(BuzzDisappear, 10, 12);
		}

		private void BuzzDisappear() {
			GameObject.FindObjectOfType<GetPath>().PlayPath(Buzzword, "walkToScene", 0, true);
			GameObject.FindObjectOfType<GetPath>().PlayPath(GameObject.Find("PlayerHolder"), "playerWalkToScene");
		}

		private void BuzzEnd() {
			Buzzword.GetComponent<PlayVideo>().EnqueueAllScenes("The winners are", team.Contestants[0], "And", team.Contestants[1], "Come up and say something");
		}

		public override void BeforeStart() {
		}
	}
}
