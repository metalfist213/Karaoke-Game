using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMultiple : MonoBehaviour
{
	public GameObject obj;
	public bool needsUpdate;
	public int timesX, timesY, timesZ;
	public float offsetX = 1;
	public float offsetY = 1;
	public float offsetZ = 1;
	private Vector3 size;
    void Start()
    {
		size = obj.GetComponent<MeshRenderer>().bounds.size;
		UpdateChanges();
	}

	private void UpdateChanges() {
		for(int x = 0; x < timesX; x++) {
			GameObject newObj = GameObject.Instantiate(obj);
			newObj.transform.SetParent(this.transform);
			newObj.transform.position = new Vector3(x*(size.x), 0, 0);
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (needsUpdate) needsUpdate = false;
    }
}
