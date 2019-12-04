using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceController : MonoBehaviour
{
	private List<MultiDirChanger> audience;
	private string lastAudience;
	private WebServer server;
	private FutureScene scene;
    void Start()
    {
		audience = new List<MultiDirChanger>();
		audience.AddRange(GameObject.FindObjectsOfType<MultiDirChanger>());
		server = GameObject.FindObjectOfType<WebServer>();
		scene = server.GetNextScene();
	}

    // Update is called once per frame
    void Update()
    {
		string next = scene.audienceType;

		if(scene.audienceType != lastAudience) {
			audience.ForEach(x=>x.currentClipCollection = next);
		}
		lastAudience = scene.audienceType;
	}
}
