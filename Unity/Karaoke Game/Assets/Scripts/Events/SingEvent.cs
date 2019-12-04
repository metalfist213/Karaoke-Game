using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Events
{
	class SingEvent : KaraokeEventCollection
	{
		private Team thisTeam;
		public SingEvent(GameObject buzzword, GameObject camera, GameObject audience) : base(buzzword, camera, audience) {
			
		}

		private void BuzzwordDisappear() {
			
			GameObject.FindObjectOfType<GetPath>().PlayPath(Buzzword, "walkToScene", 0, true);
			GameObject.FindObjectOfType<GetPath>().PlayPath(GameObject.Find("PlayerHolder"), "playerWalkToScene");
		}

		private void PresentatingNextContenders() {
			GameObject.Find("Team Registration Canvas").GetComponent<Canvas>().enabled = false;
			thisTeam = GameObject.Find("Server").GetComponent<WebServer>().GetNextTeam();
			Buzzword.GetComponent<PlayVideo>().EnqueueAllScenes("Next Contenders", thisTeam.Contestants[0], "And", thisTeam.Contestants[1]);
		}

		public override void BeforeStart() {
			this.requiresContinue = true;
			AddEvent(PresentatingNextContenders, 0, 45);
			AddEvent(BuzzwordDisappear, 3, 45);
			AddEvent(() => {
				Audience.GetComponent<MultiSoundPlayer>().PlayTrack("Applause", .02f);
			}, 3, 0);
		}

		public override void BeforeNext() {
			GameObject.FindObjectOfType<EventController>().EnqueueEvent(new RantEvent(Buzzword, Camera, Audience));
		}
	}
}
