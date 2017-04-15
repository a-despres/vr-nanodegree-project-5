using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	private Camera camera;
	private GameObject previousMarker;

	// Use this for initialization
	void Start () {
		camera = GetComponentInChildren<Camera> ();
	}

	public void TeleportToMarker (GameObject marker) {

		// Unhide previous marker
		if (previousMarker != null) {
			previousMarker.SetActive (true);
		}

		// Hide current marker
		marker.SetActive (false);

		// Move camera to marker with offset
		camera.transform.position = new Vector3(marker.transform.position.x + 0.5f, marker.transform.position.y, marker.transform.position.z - 1);

		// Set current marker as previous marker
		previousMarker = marker;
	}
}