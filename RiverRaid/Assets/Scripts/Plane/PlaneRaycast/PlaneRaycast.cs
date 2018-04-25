using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRaycast : MonoBehaviour {

	private Animator planeAnimator;
	private Rigidbody2D planeRb;

	void Start () {
		planeAnimator = GetComponent<Animator>();
		planeRb = GetComponent<Rigidbody2D>();
	}
	
	void OnTriggerEnter2D(Collider2D planeCollider){
		planeAnimator.SetBool("isDead", true);
		planeRb.isKinematic = true;
	}

}
