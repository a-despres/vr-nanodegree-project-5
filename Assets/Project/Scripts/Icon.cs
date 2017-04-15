using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour {

	private Animator animator;
	private ParticleSystem particleSystem;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		particleSystem = GetComponentInChildren<ParticleSystem> ();
	}
	
	public void StartSpin () {
		animator.SetBool ("isSpinning", true);
//		if (!particleSystem.isPlaying) {
			particleSystem.Play ();
//		}
	}

	public void StopSpin () {
		animator.SetBool ("isSpinning", false);
//		if (particleSystem.isPlaying) {
			particleSystem.Stop ();
//		}
	}
}
