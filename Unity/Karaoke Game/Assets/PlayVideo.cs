using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
	public Queue<VideoClip> clips;
	public VideoPlayer player1;
	public VideoPlayer player2;

	private VideoPlayer current;
	private VideoPlayer other;
	public int frameBeforeSkipping=15;
	private bool otherChanged=true;

	public string tester;

	void Start() {
		player1.loopPointReached += OnClipEnd;
		player1.started += OnStarted;
		player2.loopPointReached += OnClipEnd;
		player2.started += OnStarted;
		clips = new Queue<VideoClip>();/*
		clips.Enqueue(FindObjectOfType<ClipsLibary>().GetOneSidedClip("RunningToStance"));
		clips.Enqueue(FindObjectOfType<ClipsLibary>().GetOneSidedClip("Thank you Dick"));
		clips.Enqueue(FindObjectOfType<ClipsLibary>().GetOneSidedClip("Dirty Slut and Repeat"));
		clips.Enqueue(FindObjectOfType<ClipsLibary>().GetOneSidedClip("Rated By"));
		clips.Enqueue(FindObjectOfType<ClipsLibary>().GetOneSidedClip("Word is Law"));
		clips.Enqueue(FindObjectOfType<ClipsLibary>().GetOneSidedClip("Go and Register"));
		clips.Enqueue(FindObjectOfType<ClipsLibary>().GetOneSidedClip("Andreas"));
		clips.Enqueue(FindObjectOfType<ClipsLibary>().GetOneSidedClip("And"));
		clips.Enqueue(FindObjectOfType<ClipsLibary>().GetOneSidedClip("Anna-Sofie"));*/
		current = player1;
		other = player2;

		StartAgain();
	}

	void StartAgain() {

		current = player1;
		other = player2;

		if (clips.Count >= 1) {
			current.clip = clips.Dequeue();
			current.Play();
		}
		if (clips.Count >= 1) {
			other.clip = clips.Dequeue();
			other.Prepare();
		}
	}

	public void EnqueueAllScenes(params string[] names) {
		foreach(string str in names) {
			clips.Enqueue(FindObjectOfType<ClipsLibary>().GetOneSidedClip(str));
		}
		StartAgain();
	}

	public void OnStarted(VideoPlayer player) {
		player.GetComponent<MeshRenderer>().enabled = true;
	}
	public void OnClipEnd(VideoPlayer player) {
		other = (player == player1) ? player2 : player1;
		Debug.Log(clips.Count);

		if(clips.Count>0) {
			player.clip = clips.Dequeue();
			player.GetComponent<MeshRenderer>().enabled = false;
			player.Prepare();


			other.Play();
			current = other;
			other = player;
			otherChanged = true;
		} else {
			if (!otherChanged) return;
			Debug.Log("Here");
			otherChanged = false;
			other.Play();
			player.GetComponent<MeshRenderer>().enabled = false;
			current = other;
			other = player;
		}
	}

    // Update is called once per frame
    void Update()
    {
    }
}
