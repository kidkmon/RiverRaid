using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour {

	[SerializeField] private Transform respawnPosition;
	[SerializeField] private Transform cameraStartPosition;

	[SerializeField] private Camera mainCamera;

	void OnCollisionEnter2D(Collision2D collider) {
		if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "Bullet" ){
			respawnPosition.position = transform.position;
			cameraStartPosition.position = new Vector3(cameraStartPosition.position.x, transform.position.y + 0.489f, cameraStartPosition.position.z);
			StartCoroutine(BridgeDestroyed());
		}
	}

	IEnumerator BridgeDestroyed(){
		mainCamera.backgroundColor = new Color32(153,51,153,255);
		GetComponent<BoxCollider2D>().enabled = false;
		GetComponent<Animator>().SetBool("isDead", true);
		yield return new WaitForSeconds(0.8f);
		Destroy(gameObject);
		mainCamera.backgroundColor = new Color32(45,50,184,0);
	}

}
