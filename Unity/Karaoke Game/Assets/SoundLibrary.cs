using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour
{
	[SerializeField]
	private List<AudioClip> sounds;

	public AudioClip GetAudioClip(string name) {
		return sounds.Find((x) => x.name == name);
	}
}
