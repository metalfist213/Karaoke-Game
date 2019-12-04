using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSoundPlayer : MonoBehaviour
{
	private List<AudioSource> sources;
    void Start()
    {
		sources = new List<AudioSource>();
    }

	public void PlayTrack(string name, float volume=1) {
		AudioClip clip = FindObjectOfType<SoundLibrary>().GetAudioClip(name);

		if(clip==null) {
			Debug.LogError("Audio clip: " + name + " not found!");
		} else {
			AudioSource s = gameObject.AddComponent<AudioSource>();
			s.volume = volume;
			s.PlayOneShot(clip);
		}
	}

	private void Update() {
		sources.RemoveAll(x => !x.isPlaying);
	}
}
