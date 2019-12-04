using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Events
{
	public class IntroEvents : KaraokeEventCollection
	{
		public IntroEvents(GameObject buzzword, GameObject camera, GameObject audience) : base(buzzword, camera, audience) {
		}

		public override void BeforeStart() {
			AddEvent(CommentatorSpeaking, 0, 45);
			AddEvent(Applause, 13, 45);
			AddEvent(PlayTitleMelody, 13, 45);
			AddEvent(PlayTitle, 14, 45);
			AddEvent(CamMoveBack, 20.5f, 45);
			AddEvent(StartRegistration, 56, 0);
			AddEvent(PlayBeFather, 25, 10);
			AddEvent(BackToFace, 27, 10);
			AddEvent(StrollAudience, 23.5f, 10);
			this.requiresContinue = true;
		}
		private void StrollAudience() {
			GameObject.FindObjectOfType<GetPath>().PlayPath(Camera, "AudienceStroll", 0, true);
			GameObject.FindObjectOfType<GetPath>().PlayPath(Camera, "AudienceStroll");
		}

		private void BackToFace() {
			GameObject.FindObjectOfType<WebServer>().GetNextScene().audienceType = "looking";
			GameObject.FindObjectOfType<GetPath>().PlayPath(Camera, "sceneFurther", 0, true);
		}
		private void StartRegistration() {
			MoveInfo cam = new MoveInfo(new Vector3(-3.42f, 2.19f, 2.51f), new Vector3(15.73f, 28.06f, 0));
			cam.rotSpeed = .1f;
			cam.speed = 1f;
			Audience.GetComponent<MultiSoundPlayer>().PlayTrack("Title Melody", .03f);
			Audience.GetComponent<MultiSoundPlayer>().PlayTrack("Applause", .02f);
			Camera.GetComponent<PathMover>().QueueMovement(cam);

			GameObject.Find("Team Registration Canvas").GetComponent<Canvas>().enabled = true;
		}

		private void CamMoveBack() {
			GameObject.FindObjectOfType<WebServer>().GetNextScene().audienceType = "dabbing";
			GameObject.FindObjectOfType<GetPath>().PlayPath(Camera, "sceneFurther");
		}

		private void Applause() {
			GameObject.FindObjectOfType<WebServer>().GetNextScene().audienceType = "clapping";
			Audience.GetComponent<MultiSoundPlayer>().PlayTrack("Applause", .02f);
		}

		private void CommentatorSpeaking() {
			Audience.GetComponent<MultiSoundPlayer>().PlayTrack("Commentator", .1f);
		}

		private void PlayTitleMelody() {
			Audience.GetComponent<MultiSoundPlayer>().PlayTrack("Title Melody", .03f);
		}

		private void PlayBeFather() {
			Audience.GetComponent<MultiSoundPlayer>().PlayTrack("Become the father of my children", .02f);
		}

		public void PlayTitle() {
			GameObject.FindObjectOfType<GetPath>().PlayPath(Buzzword, "walkToScene");
			GameObject.FindObjectOfType<GetPath>().PlayPath(Camera, "sceneCloseup");
			Buzzword.GetComponent<PlayVideo>().EnqueueAllScenes("RunningToStance", "Thank you Dick", "Dirty Slut and Repeat", "Rated By",
			"Word is Law", "Go and Register");
		}
	}
}
