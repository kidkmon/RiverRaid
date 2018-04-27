using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelObject : MonoBehaviour {

	[SerializeField] private Transform measureFuelPosition;
	[SerializeField] private AudioSource fuelSong;
	private float timeTemp;

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.tag == "Player"){
			fuelSong.Play();
		}
		if(collider.gameObject.tag == "Bullet"){
			StartCoroutine(DeathAnimation());
			Destroy(collider.gameObject);
		}
	}
	void OnTriggerStay2D(Collider2D collider) {
		if(collider.gameObject.tag == "Player"){
			timeTemp += 0.002f;
			if(measureFuelPosition.position.x <= 0.25f){
					measureFuelPosition.position = new Vector3(measureFuelPosition.position.x + timeTemp, measureFuelPosition.position.y, measureFuelPosition.position.z);
					timeTemp = 0;
			}

		}
	}

	IEnumerator DeathAnimation(){
		GetComponent<BoxCollider2D>().enabled = false;
		GetComponent<Animator>().SetBool("isShortDead", true);
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}
}
