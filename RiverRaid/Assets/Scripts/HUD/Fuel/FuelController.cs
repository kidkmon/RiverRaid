using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour {

	private float timeTemp;

	public static bool noFuel;

	void FixedUpdate() {

		if(CameraStart.gameStarted && !PlaneRaycast.isDead){
			if(transform.position.x > -0.27f){
				timeTemp += Time.deltaTime;
				if(timeTemp > 1.5f){
					transform.position = new Vector3(transform.position.x - 0.030f, transform.position.y, transform.position.z);
					timeTemp = 0;
				}
			}
			else{
				noFuel = true;
			}
		}
		if(!CameraStart.gameStarted){
			transform.position = new Vector3(0.30f, transform.position.y, transform.position.z);
		}
		
	}

}
