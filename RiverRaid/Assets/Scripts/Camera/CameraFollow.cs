using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Rigidbody2D cameraRb;
	private float verticalValue;

	void Start() {
		cameraRb = GetComponent<Rigidbody2D>();
	}

	void Update() {

		
		if(Input.GetKey(KeyCode.UpArrow)){
			verticalValue = 0.5f;
			cameraRb.velocity = new Vector2(0, verticalValue);
		}
		else if(Input.GetKey(KeyCode.DownArrow)){
			verticalValue = 0.125f;
			cameraRb.velocity = new Vector2(0, verticalValue);
		}
		else{
			verticalValue = 1f;
			cameraRb.velocity = new Vector2(0, verticalValue);
		}
	}
}
