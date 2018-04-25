using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	[SerializeField] private Rigidbody2D planeRb;
	private Rigidbody2D cameraRb;
	private float verticalValue;

	void Start() {
		cameraRb = GetComponent<Rigidbody2D>();
	}

	void Update() {

		
		if(Input.GetKey(KeyCode.UpArrow)){
			verticalValue = 0.5f;
		}
		else if(Input.GetKey(KeyCode.DownArrow)){
			verticalValue = 0.125f;
		}
		else{
			verticalValue = 0.25f;
		}

		cameraRb.velocity = new Vector2(0, verticalValue);
		planeRb.velocity = new Vector2(planeRb.velocity.x, verticalValue);
	}
}
