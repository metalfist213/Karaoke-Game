using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ClipsLibary : MonoBehaviour
{
	[SerializeField]
	private List<VideoClip> oneSidedClips;
	[SerializeField]
	private List<MultiSidedClip> multiSidedClips;
	// Start is called before the first frame update

	public VideoClip GetOneSidedClip(string name) {
		VideoClip clip = oneSidedClips.Find((x) => x.name == name);
		if(clip==null) {
			Debug.LogError("Warning. The Video: " + name + " Could not be found!");
		}


		return clip;
	}
	public MultiSidedClip GetMultiSidedClip(string name) {
		return multiSidedClips.Find((x) => x.name == name);
	}
}
[Serializable]
public class MultiSidedClip
{
	public string name;
	public VideoClip left;
	public VideoClip right;
	public VideoClip front;
	public VideoClip back;
}