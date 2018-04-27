using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneRaycast : MonoBehaviour {

	[SerializeField] private GameObject mainCamera;
	[SerializeField] private Transform SpawnPosition;
	[SerializeField] private Text lifeCount;
	private Animator planeAnimator;
	public static bool isDead;
	
	void Start () {
		planeAnimator = GetComponent<Animator>();
	}
	
	void Update() {
		if(FuelController.noFuel){
			StartCoroutine(DeathCoolDown());
		}	
	}

	void OnCollisionEnter2D(Collision2D planeCollider){
		StartCoroutine(DeathCoolDown());
	}

	IEnumerator DeathCoolDown(){
		isDead = true;
		FuelController.noFuel = false;
		planeAnimator.SetBool("isDead", true);
		yield return new WaitForSeconds(2);
		if(lifeCount.text == ""){}
		else if(int.Parse(lifeCount.text) > 0){
			isDead = false;
			CameraStart.gameStarted = false;
			planeAnimator.SetBool("isDead", false);
			transform.position = SpawnPosition.position;
			mainCamera.GetComponent<CameraFollow>().enabled = false;
			gameObject.SetActive(false);
			mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, SpawnPosition.position.y - 0.5f, mainCamera.transform.position.z);
			mainCamera.GetComponent<CameraStart>().enabled = true;
			lifeCount.text = (int.Parse(lifeCount.text) - 1).ToString();
			if(int.Parse(lifeCount.text) == 0){
				lifeCount.text = "";
			}
		}
		
		
	}

}
