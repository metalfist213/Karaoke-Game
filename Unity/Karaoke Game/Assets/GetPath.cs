using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPath : MonoBehaviour
{
	public List<MovementCollection> collections;
   
	public void PlayPath(GameObject obj, string pathName, int startingFrom = 0, bool teleToFirstPosition = false) {
		MovementCollection coll = collections.Find(x=>x.name==pathName);
		if (coll == null) {
			Debug.LogError("Movement Collection: " + coll + " Was not found!");
			return;
		}
		if (!teleToFirstPosition) {

			for(int i = startingFrom; i < coll.moveInfo.Count; i++) {
				obj.GetComponent<PathMover>().QueueMovement(coll.moveInfo[i]);
			}
		} else {
			obj.GetComponent<PathMover>().TeleObject(coll.moveInfo[startingFrom]);
		}
	}
}

[Serializable]
public class MovementCollection
{
	public string name;
	public List<MoveInfo> moveInfo;
}