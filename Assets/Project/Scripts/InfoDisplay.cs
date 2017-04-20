using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GVR;

public class InfoDisplay : MonoBehaviour {
	public bool isActive = false;
	public RawImage photo;
	public Text caption;
	public Text title;
	public Text description;

	public Texture fieldtrip;

	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager> ();
	}

	public void StartExperience () {
		gameManager.audioManager.PlayClick ();
		GvrViewer camera = FindObjectOfType<GvrViewer> ();
		camera.transform.position = new Vector3 (11, 2, 0);
	}

	public void Set (Icon subject) {
		title.text = subject.title;
		description.text = subject.description;
		photo.texture = subject.photo;
		caption.text = subject.caption;
	}

	public void Close () {
		if (gameManager.infoDisplayInstance != null) {
			gameManager.EnableIcons ();
			gameManager.audioManager.PlayClick ();
			Collider collider = gameManager.currentMarker.paper.GetComponent<Collider> ();
			collider.enabled = true;
			Destroy (gameObject);
		} else {
			print ("Error: Info Display could not be destroyed.");
		}
	}
}
