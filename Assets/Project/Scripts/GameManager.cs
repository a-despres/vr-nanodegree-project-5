using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public InfoDisplay infoDisplay;
	public InfoDisplay infoDisplayInstance;
	public Icon currentMarker;

	private Camera camera;
	public AudioManager audioManager;
	private Icon[] icons;

	// Use this for initialization
	void Start () {
		camera = FindObjectOfType<Camera> ();

		// Find all of the icons in the scene
		icons = FindObjectsOfType<Icon> ();
	}

	public void ShowInfoDisplay (Icon forSubject) {
		infoDisplayInstance = Instantiate (infoDisplay);

		if (infoDisplayInstance != null) {
			audioManager.PlayClick ();
			DisableIcons ();
			DisablePapers ();
			infoDisplayInstance.transform.position = new Vector3(camera.transform.position.x - 2, 2, camera.transform.position.z);
			infoDisplayInstance.Set (forSubject);
		} else {
			print ("Error: Info Display Not Initialized");
		}
	}

	public void DisablePapers () {
		if (icons.Length > 0) {
			foreach (Icon icon in icons) {
				Collider collider = icon.paper.GetComponent<Collider> ();
				collider.enabled = false;
			}
		}
	}

	public void DisableIcons () {
		if (icons.Length > 0) {
			foreach (Icon icon in icons) {
				icon.gameObject.SetActive (false);
			}
		} else {
			print ("Error: No Icons could be found.");
		}
	}

	public void EnableIcons () {
		if (icons.Length > 0) {
			foreach (Icon icon in icons) {
				if (icon != currentMarker) {
					icon.gameObject.SetActive (true);
				}
			}
		} else {
			print ("Error: No Icons could be found.");
		}
	}
}
