using Assets.Scripts.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
	public GameObject webserver, jackBuzzword, cam, audienceSound;
	private Queue<KaraokeEventCollection> events;
	private KaraokeEventCollection currentlyRunning;
	private static float currentDelta;

	public static float CurrentDelta { get => currentDelta; }

	// Start is called before the first frame update
	void Start()
    {
		if(Display.displays.Length > 1) {
			Display.displays[1].Activate();
		}
		events = new Queue<KaraokeEventCollection>();
		events.Enqueue(new IdleEvent(jackBuzzword, cam, audienceSound));
		events.Enqueue(new IntroEvents(jackBuzzword, cam, audienceSound));
		events.Enqueue(new SingEvent(jackBuzzword, cam, audienceSound));
	}
	public void EnqueueEvent(KaraokeEventCollection coll) {
		this.events.Enqueue(coll);
	}
    // Update is called once per frame
    void Update()
    {
		currentDelta = Time.deltaTime;

		if (currentlyRunning!=null) {
			currentlyRunning.Update();
			if (currentlyRunning.Done || FindObjectOfType<WebServer>().GetNextScene().continueShow) {
				if (!currentlyRunning.RequiresContinue() || FindObjectOfType<WebServer>().GetNextScene().continueShow) {
					currentlyRunning.BeforeNext();
					currentlyRunning = null;
					FindObjectOfType<WebServer>().GetNextScene().continueShow = false;
				}
			}
		}

		if(currentlyRunning == null && events.Count > 0) {
			currentlyRunning = events.Dequeue();
			currentlyRunning.Start();
		}
    }
}
