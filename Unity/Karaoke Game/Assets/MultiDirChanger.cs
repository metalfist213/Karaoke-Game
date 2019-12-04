using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Video;

public class MultiDirChanger : MonoBehaviour
{
	public GameObject front, back, left, right;
	public string currentClipCollection;
	private string lastClipCollection;
	private ClipsLibary library;
	private Dictionary<Camera, GameObject> binds; 

	private void BindCamera(Camera cam, GameObject angle) {
		binds[cam] = angle;

		angle.GetComponent<VideoPlayer>().Play();

		if (!binds.ContainsValue(left)) {
			left.GetComponent<VideoPlayer>().Stop();
		}
		if (!binds.ContainsValue(right)) {
			right.GetComponent<VideoPlayer>().Stop();
		}
		if (!binds.ContainsValue(front)) {
			front.GetComponent<VideoPlayer>().Stop();
		}
		if (!binds.ContainsValue(back)) {
			back.GetComponent<VideoPlayer>().Stop();
		}
	}
	private void PlayClip(GameObject angle) {
		if(!angle.GetComponent<VideoPlayer>().isPlaying) {
			angle.GetComponent<VideoPlayer>().Play();
		}
	}
	public void ChangeDir(Camera cam) {
		float rotation = cam.transform.rotation.eulerAngles.y;
		if (rotation < 45 || rotation >= 360 - 45) { //back
			front.GetComponent<MeshRenderer>().enabled = false;
			back.GetComponent<MeshRenderer>().enabled = true;
			left.GetComponent<MeshRenderer>().enabled = false;
			right.GetComponent<MeshRenderer>().enabled = false;

			BindCamera(cam, back);

		} else if (rotation < 90 + 45 && rotation >= 90 - 45) { //left
			front.GetComponent<MeshRenderer>().enabled = false;
			back.GetComponent<MeshRenderer>().enabled = false;
			left.GetComponent<MeshRenderer>().enabled = true;
			right.GetComponent<MeshRenderer>().enabled = false;

			BindCamera(cam, left);

		} else if (rotation < 180 + 45 && rotation >= 180 - 45) { //front
			front.GetComponent<MeshRenderer>().enabled = true;
			back.GetComponent<MeshRenderer>().enabled = false;
			left.GetComponent<MeshRenderer>().enabled = false;
			right.GetComponent<MeshRenderer>().enabled = false;

			BindCamera(cam, front);

		} else { //right
			front.GetComponent<MeshRenderer>().enabled = false;
			back.GetComponent<MeshRenderer>().enabled = false;
			left.GetComponent<MeshRenderer>().enabled = false;
			right.GetComponent<MeshRenderer>().enabled = true;

			BindCamera(cam, right);

		}
		/*
		if(cam.transform.position.z < transform.position.z) {
			front.GetComponent<MeshRenderer>().enabled = false;
			back.GetComponent<MeshRenderer>().enabled = true;
		} else {
			back.GetComponent<MeshRenderer>().enabled = false;
			front.GetComponent<MeshRenderer>().enabled = true;
		}*/
	}


	private void Update() {
		if (currentClipCollection != lastClipCollection) {
			MultiSidedClip next = library.GetMultiSidedClip(currentClipCollection);
			if (next != null) {
				StartCoroutine(ChangeClip(next));


				lastClipCollection = currentClipCollection;
			}
		}
	}
	IEnumerator ChangeClip(MultiSidedClip next) {
		VideoPlayer newFront, newBack, newLeft, newRight;

		VideoPlayer currentFront, currentBack, currentLeft, currentRight;

		VideoPlayer[] oldOnes = this.GetComponentsInChildren<VideoPlayer>();

		currentFront = front.GetComponent<VideoPlayer>();
		currentBack = back.GetComponent<VideoPlayer>();
		currentLeft = left.GetComponent<VideoPlayer>();
		currentRight = right.GetComponent<VideoPlayer>();

		newFront = InitializeWithCorrectSettings(front);
		newBack = InitializeWithCorrectSettings(back);
		newLeft = InitializeWithCorrectSettings(left);
		newRight = InitializeWithCorrectSettings(right);

		newFront.clip = next.front;
		newBack.clip = next.back;
		newLeft.clip = next.left;
		newRight.clip = next.right;

		newFront.Prepare();
		newBack.Prepare();
		newLeft.Prepare();
		newRight.Prepare();

		while(!OneCamNull(newFront, newRight, newLeft, newBack)&&
			!newFront.isPrepared &&
			!newBack.isPrepared &&
			!newLeft.isPrepared &&
			!newRight.isPrepared) {
			yield return new WaitForSeconds(.0001f);
		}


		foreach(VideoPlayer player in oldOnes) {
			Destroy(player);
		}



		yield return null;
	}

	private bool OneCamNull(params VideoPlayer[] players) {
		foreach(VideoPlayer player in players) {
			if (player == null) return true;
		}
		return false;
	}

	private VideoPlayer InitializeWithCorrectSettings(GameObject target) {
		VideoPlayer p = target.AddComponent<VideoPlayer>();
		p.isLooping = true;
		p.targetMaterialRenderer= target.GetComponent<MeshRenderer>();
		p.playOnAwake = true;
		p.audioOutputMode = VideoAudioOutputMode.None;

		return p;
	}

	private void Start() {
		library = FindObjectOfType<ClipsLibary>();
		RenderPipeline.beginCameraRendering += ChangeDir;
		binds = new Dictionary<Camera, GameObject>();
	}

	private void OnDisable() {
		RenderPipeline.beginCameraRendering -= ChangeDir;
	}
}
