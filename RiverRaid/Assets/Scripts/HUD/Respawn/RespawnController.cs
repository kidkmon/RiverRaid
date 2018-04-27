using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour {

	[SerializeField] private Transform respawnPosition;
	[SerializeField] private Transform cameraStartPosition;

	void OnCollisionEnter2D(Collision2D collider) {
		if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "Bullet" ){
			respawnPosition.position = transform.position;
			cameraStartPosition.position = new Vector3(cameraStartPosition.position.x, transform.position.y + 0.489f, cameraStartPosition.position.z);
			Destroy(gameObject);
		}
	}

}
