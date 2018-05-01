using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

	private Animator planeAnimator;
	private Rigidbody2D planeRb;

	private float moveForce = 0.8f;
	private float timeTemp;
	private float spriteTime = 0.1f;

	private bool isLeft;
	private bool isRight;

	void Start () {
		planeAnimator = GetComponent<Animator>();
		planeRb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

		if(!PlaneRaycast.isDead){
			float horizontalValue = Input.GetAxis("Horizontal");

			if(Input.GetKey(KeyCode.LeftArrow)){
				isLeft = true;
				isRight = false;
				timeTemp = 0f;
			}
			if(Input.GetKey(KeyCode.RightArrow)){
				isRight = true;
				isLeft = false;
				timeTemp = 0f;
			}

			if(isLeft || isRight){
				timeTemp += Time.deltaTime;
				if(timeTemp >= spriteTime){
					isLeft = false;
					isRight = false;
				}
			}

			planeRb.velocity = new Vector2(horizontalValue * moveForce, 0f);

			planeAnimator.SetBool("isRight", isRight);
			planeAnimator.SetBool("isLeft", isLeft);
		}
	}
}
