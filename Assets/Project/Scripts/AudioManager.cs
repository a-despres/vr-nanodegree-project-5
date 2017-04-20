using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip chime;
	public AudioClip click;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	public void PlayChime () {
		if (audioSource != null) {
			audioSource.clip = chime;
			audioSource.Play ();
		}
	}

	public void PlayClick () {
		if (audioSource != null) {
			audioSource.clip = click;
			audioSource.Play ();
		}
	}
}
