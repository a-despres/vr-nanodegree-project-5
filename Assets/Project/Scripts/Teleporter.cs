using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GVR;

public class Teleporter : MonoBehaviour {

	private GvrViewer camera;
	private GameManager gameManager;
	private Icon previousMarker;

	// Use this for initialization
	void Start () {
		camera = GetComponentInChildren<GvrViewer> ();
		gameManager = FindObjectOfType<GameManager> ();
	}

	public void TeleportToMarker (Icon marker) {

		// Play Chime
		gameManager.audioManager.PlayChime ();

		// Set current marker in GameManager
		gameManager.currentMarker = marker;

		// Unhide previous marker
		if (previousMarker != null) {
			previousMarker.gameObject.SetActive (true);
		}

		// Activate Collider of Associated Paper
		marker.EnablePaper ();

		// Hide current marker
		marker.gameObject.SetActive (false);

		// Move camera to marker with offset
		camera.transform.position = new Vector3(marker.transform.position.x + 0.5f, marker.transform.position.y, marker.transform.position.z - 1);

		// Set current marker as previous marker
		previousMarker = marker;
	}
}