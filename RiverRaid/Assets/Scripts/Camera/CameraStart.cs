using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStart : MonoBehaviour {

	[SerializeField] private Transform SpawnPosition;
	[SerializeField] private GameObject plane;
	[SerializeField] private GameObject lifeCount; 
	[SerializeField] private GameObject selectedPrefab;
	// [SerializeField] private List<GameObject> resetEnemys;	

	private float cameraSpeed = 0.025f;
	private Vector3 desiredPosition;
	
	public static bool gameStarted;
	
	void Start () {
		EventManager.OnPlaneDeathEvent += onPlaneDeathListener;
	}

	void OnDestroy() {
		EventManager.OnPlaneDeathEvent -= onPlaneDeathListener;
	}

	void onPlaneDeathListener(){
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Scenario")) {
        	Destroy(obj);
    	}
		Debug.Log("Instanciando novo segmento...");
		GameObject newSegment = Instantiate(
			selectedPrefab,
			new Vector2(0, 0),
			Quaternion.identity
		);
	}
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
	}
}