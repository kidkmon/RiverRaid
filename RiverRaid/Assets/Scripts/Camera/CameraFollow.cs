using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	[SerializeField] private AudioSource[] planeSounds;
	[SerializeField] private Rigidbody2D planeRb;
	private Rigidbody2D cameraRb;
	private float verticalValue;

	void Start() {
		cameraRb = GetComponent<Rigidbody2D>();
	}

	void Update() {

		if(Input.GetKey(KeyCode.UpArrow)){
			if(!planeSounds[0].isPlaying){
				planeSounds[0].Play();
			}
			planeSounds[1].Stop();
			planeSounds[2].Stop();
			verticalValue = 0.75f;
		}
		else if(Input.GetKey(KeyCode.DownArrow)){
			if(!planeSounds[1].isPlaying){
				planeSounds[1].Play();
			}
			planeSounds[0].Stop();
			planeSounds[2].Stop();
			 verticalValue = 0.25f;
		}
		else{
			if(!planeSounds[2].isPlaying){
				planeSounds[2].Play();
			}
			planeSounds[0].Stop();
			planeSounds[1].Stop();
			verticalValue = 0.5f;
		}

		if(PlaneRaycast.isDead){
			cameraRb.velocity = new Vector2(0,0);
			planeRb.velocity = new Vector2(0,0);
			foreach(AudioSource planeSound in planeSounds){
				planeSound.Stop();
			}
		}
		else{
			cameraRb.velocity = new Vector2(0, verticalValue);
			planeRb.velocity = new Vector2(planeRb.velocity.x, verticalValue);
		}
	}
}
