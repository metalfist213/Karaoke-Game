using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotater : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject lookAtTool, target, rotaterX, rotaterY, light1, light2;
	public Color lightColor;
	void Start() {
		lookAtTool.transform.LookAt(target.transform.position);
		Debug.Log(lookAtTool.transform.rotation.eulerAngles);

	}

	// Update is called once per frame
	void Update() {
		lookAtTool.transform.LookAt(target.transform.position);

		rotaterX.transform.rotation = Quaternion.Euler(lookAtTool.transform.rotation.eulerAngles.x, lookAtTool.transform.rotation.eulerAngles.y, rotaterX.transform.rotation.eulerAngles.z);
		rotaterY.transform.rotation = Quaternion.Euler(0, lookAtTool.transform.rotation.eulerAngles.y, rotaterY.transform.rotation.eulerAngles.z);
		UpdateColor();
	}

	public void UpdateColor() {
		light1.GetComponent<Light>().color = lightColor;
		light2.GetComponent<Light>().color = lightColor;
	}
}
