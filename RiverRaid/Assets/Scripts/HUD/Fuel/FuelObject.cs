using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelObject : MonoBehaviour {

	[SerializeField] private Transform measureFuelPosition;
	[SerializeField] private AudioSource[] fuelSong;
	private float timeTemp;


	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.tag == "Bullet"){
			StartCoroutine(DeathAnimation());
			Destroy(collider.gameObject);
		}
	}
	void OnTriggerStay2D(Collider2D collider) {
		if(collider.gameObject.tag == "Player"){
			timeTemp += 0.0018f;
			if(measureFuelPosition.position.x <= 0.27f){
				if(!fuelSong[0].isPlaying){
					fuelSong[0].Play();
				}
				fuelSong[1].Stop();
				measureFuelPosition.position = new Vector3(measureFuelPosition.position.x + timeTemp, measureFuelPosition.position.y, measureFuelPosition.position.z);
				timeTemp = 0;
			}
			else{
				if(!fuelSong[1].isPlaying){
					fuelSong[1].Play();
				}
				fuelSong[0].Stop();
			}

		}
	}

	IEnumerator DeathAnimation(){
		fuelSong[2].Play();
		GetComponent<BoxCollider2D>().enabled = false;
		GetComponent<Animator>().SetBool("isDead", true);
		yield return new WaitForSeconds(0.6f);
		GetComponent<Animator>().SetBool("isDead", false);
		GetComponent<BoxCollider2D>().enabled = true;
		gameObject.SetActive(false);
	}
}
