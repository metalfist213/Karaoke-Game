using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Events
{
	public abstract class KaraokeEventCollection
	{
		private Thread thisThread;
		private List<KaraokeEvent> events;
		protected bool requiresContinue;
		private float timeRunning = 0f;
		private GameObject buzzword, camera, audience;
		private bool done;

		public GameObject Buzzword { get => buzzword; set => buzzword = value; }
		public GameObject Camera { get => camera; set => camera = value; }
		public bool Done { get => done; }
		public GameObject Audience { get => audience; set => audience = value; }

		public KaraokeEventCollection(GameObject buzzword, GameObject camera, GameObject audience) {
			this.Buzzword = buzzword;
			this.Camera = camera;
			this.Audience = audience;
			events = new List<KaraokeEvent>();
			BeforeStart();
		}


		public void AddEvent(KaraokeEvent.Method method, float startTime, float duration=0) {
			events.Add(new KaraokeEvent(method, startTime, duration));
		}

		public abstract void BeforeStart();

		public void Start() {
			Update();
		}
		public void Update() {
			List<KaraokeEvent> toRemove = new List<KaraokeEvent>();
			if (events.Count>0) {
				toRemove.Clear();
				timeRunning += Time.deltaTime;
				foreach (KaraokeEvent e in events) {
					e.Update(timeRunning);
					if (e.IsDone()) {
						toRemove.Add(e);
					}
				}

				events.RemoveAll(x => toRemove.Contains(x));
			} else {
				Halt();
			}
		}
		private void Halt() {
			done = true;
		}
		public virtual void BeforeNext() {

		}

		public bool RequiresContinue() {
			return requiresContinue;
		}
	}

	public class KaraokeEvent
	{
		public float startTime;
		public float extraTime;
		public delegate void Method();
		private Method stored;
		private bool hasRun;
		private float time;

		public bool IsStarted() {
			return hasRun;
		}

		public bool IsDone() {
			return time > startTime + extraTime;
		}

		public KaraokeEvent(Method m, float startTime, float duration=0) {
			stored = m;
			this.startTime = startTime;
			this.extraTime = duration;
		}
		public void Update(float time) {
			this.time = time;
			if (time >= startTime && !hasRun) {
				stored.Invoke();
				hasRun = true;
			}
		}
	}
}
