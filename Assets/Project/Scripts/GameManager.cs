using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public InfoDisplay infoDisplay;
	public InfoDisplay infoDisplayInstance;
	public ToolTip toolTip;
	public ToolTip toolTipInstance;
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
		CloseToolTip ();

		infoDisplayInstance = Instantiate (infoDisplay);

		if (infoDisplayInstance != null) {
			audioManager.PlayClip (currentMarker);
			DisableIcons ();
			DisablePapers ();
			infoDisplayInstance.transform.position = new Vector3(camera.transform.position.x - 2, 2, camera.transform.position.z);
			infoDisplayInstance.Set (forSubject);
		} else {
			print ("Error: Info Display Not Initialized");
		}
	}

	public void ShowToolTip (Icon forSubject) {
		toolTipInstance = Instantiate (toolTip);

		if (toolTipInstance != null) {
			toolTipInstance.transform.position = new Vector3(currentMarker.transform.position.x, currentMarker.transform.position.y - 0.7f, currentMarker.transform.position.z);
			toolTipInstance.transform.rotation = camera.transform.rotation;
			toolTipInstance.Set (forSubject);
		} else {
			print ("Error: Tool Tip Not Initialized");
		}
	}

	public void CloseToolTip () {
		if (toolTipInstance != null) {
			Destroy (toolTipInstance.gameObject);
		} else {
			print ("Error: Tool Tip Could Not Be Destroyed");
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
