using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour {

	public string title;
	public string description;
	public Texture photo;
	public string caption;
	public AudioClip audio;

	public GameObject paper;

	private Animator animator;
	private ParticleSystem particleSystem;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		particleSystem = GetComponentInChildren<ParticleSystem> ();
		gameManager = FindObjectOfType<GameManager> ();
	}
	
	public void StartSpin () {
		animator.SetBool ("isSpinning", true);
		particleSystem.Play ();
	}

	public void StopSpin () {
		animator.SetBool ("isSpinning", false);
		particleSystem.Stop ();
	}

	public void ShowInfo () {
		if (gameManager != null) {
			DisablePaper ();
			gameManager.ShowInfoDisplay (this);
		}
	}

	public void EnablePaper () {
		Collider collider = paper.GetComponent<Collider> ();
		collider.enabled = true;
	}

	public void DisablePaper () {
		Collider collider = paper.GetComponent<Collider> ();
		collider.enabled = false;
	}
}
