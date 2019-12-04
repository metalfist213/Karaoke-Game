using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{

	private Queue<MoveInfo> points;
	private MoveInfo currentGoal;
	public int queueCount;
	void Start() {
		points = new Queue<MoveInfo>();
	}

	// Update is called once per frame
	void Update() {
		if (currentGoal != null) {
			MoveTowards();
		} else {
			if (points.Count != 0)
				currentGoal = points.Dequeue();
		}

		queueCount = points.Count;
	}

	private void MoveTowards() {
		float step = currentGoal.speed * Time.deltaTime;

		transform.position = Vector3.MoveTowards(transform.position, currentGoal.position, step);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(currentGoal.rotation.x, currentGoal.rotation.y, currentGoal.rotation.z), currentGoal.rotSpeed);
		

		if (Vector3.Distance(transform.position, currentGoal.position) < 0.01f && Quaternion.Angle(transform.rotation, Quaternion.Euler(currentGoal.rotation)) < 1f) {
			currentGoal = null;

		} else {
		}

	}

	public void QueueMovement(MoveInfo info) {
		points.Enqueue(info);
	}
	/// <summary>
	/// Teleports the object to the last existing object in the information.
	/// </summary>
	/// <param name="info"></param>
	public void TeleObject(MoveInfo info) {
		this.points.Clear();
		this.currentGoal = null;

		this.transform.position = info.position;
		this.transform.rotation = Quaternion.Euler( info.rotation);
	}
}
[Serializable]
public class MoveInfo
{
	public float speed = 1.2f;
	public float rotSpeed = 5f;
	public Vector3 position;
	public Vector3 rotation;

	public MoveInfo(Vector3 pos, Vector3 rot) {
		this.position = pos;
		this.rotation = rot;
	}
}
