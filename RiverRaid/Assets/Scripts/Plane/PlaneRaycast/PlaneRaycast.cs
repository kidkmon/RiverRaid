using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRaycast : MonoBehaviour {

	private Animator planeAnimator;
	public static bool isDead;

	void Start () {
		planeAnimator = GetComponent<Animator>();
	}
	
	void OnCollisionEnter2D(Collision2D planeCollider){
		isDead = true;
		planeAnimator.SetBool("isDead", true);
	}

}
