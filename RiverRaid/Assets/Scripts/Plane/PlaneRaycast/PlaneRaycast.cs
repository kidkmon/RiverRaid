using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneRaycast : MonoBehaviour {

	private Animator planeAnimator;
	public static bool isDead;
	public Text lifeCount;

	void Start () {
		planeAnimator = GetComponent<Animator>();
	}
	
	void OnCollisionEnter2D(Collision2D planeCollider){
		isDead = true;
		planeAnimator.SetBool("isDead", true);
		lifeCount.text = (int.Parse(lifeCount.text) - 1).ToString();
	}

}
