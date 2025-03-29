using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStart : MonoBehaviour {

	[SerializeField] private Transform SpawnPosition;
	[SerializeField] private GameObject plane;
	[SerializeField] private GameObject lifeCount; 
	[SerializeField] private List<GameObject> resetEnemys;	

	private float cameraSpeed = 0.025f;
	private Vector3 desiredPosition;
	
	public static bool gameStarted;
	
	void Update () {
		desiredPosition = new Vector3(transform.position.x, SpawnPosition.position.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed);

		if(transform.position.y >= SpawnPosition.position.y - 0.025f){
			ActivateAllTheObjects();
			plane.SetActive(true);
			lifeCount.SetActive(true);
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")){
				GetComponent<CameraFollow>().enabled = true;
				gameStarted = true;
				GetComponent<CameraStart>().enabled = false;	
			}
		}
	}

	void ActivateAllTheObjects(){
		foreach(GameObject enemy in resetEnemys){
			enemy.SetActive(true);
		}
	}
}
// Deteção de colisão na Unity