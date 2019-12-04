using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.IO;
using UnityEngine.Networking;

public class IpCamRenderer : MonoBehaviour
{

	public MeshRenderer mesh;    //Mesh for displaying video

	private string sourceURL = "http://192.168.0.100:8080/video";
	private Texture2D texture;
	private Stream stream;

	void Start() {
		GetVideo();
	}
	public void GetVideo() {
		texture = new Texture2D(2, 2);
		// create HTTP request
		HttpWebRequest req = (HttpWebRequest) WebRequest.Create( sourceURL );
		//Optional (if authorization is Digest)
		// get response
		WebResponse resp = req.GetResponse();
		// get response stream
		stream = resp.GetResponseStream();
		StartCoroutine(GetFrame());
		UnityWebRequest r = new UnityWebRequest();
	}

	IEnumerator GetFrame() {
		Byte [] JpegData = new Byte[65535];

		while (true) {
			int bytesToRead = FindLength(stream);
			//print(bytesToRead);
			if (bytesToRead == -1) {
				print("End of stream");
				yield break;
			}

			int leftToRead=bytesToRead;

			while (leftToRead > 0) {
				leftToRead -= stream.Read(JpegData, bytesToRead - leftToRead, leftToRead);
				yield return null;
			}

			MemoryStream ms = new MemoryStream(JpegData, 0, bytesToRead, false, true);

			texture.LoadImage(ms.GetBuffer());
			//texture.Resize(mesh.material.mainTexture.width, mesh.material.mainTexture.height);
			mesh.material.mainTexture = texture;

			stream.ReadByte(); // CR after bytes
			stream.ReadByte(); // LF after bytes
		}
	}

	int FindLength(Stream stream) {
		int b;
		string line="";
		int result=-1;
		bool atEOL=false;

		while ((b = stream.ReadByte()) != -1) {
			if (b == 10) continue; // ignore LF char
			if (b == 13) { // CR
				if (atEOL) {  // two blank lines means end of header
					stream.ReadByte(); // eat last LF
					return result;
				}
				if (line.StartsWith("Content-Length:")) {
					result = Convert.ToInt32(line.Substring("Content-Length:".Length).Trim());
				} else {
					line = "";
				}
				atEOL = true;
			} else {
				atEOL = false;
				line += (char)b;
			}
		}
		return -1;
	}
}