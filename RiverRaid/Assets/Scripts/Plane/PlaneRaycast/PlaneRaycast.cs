using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneRaycast : MonoBehaviour {

	[SerializeField] private GameObject mainCamera;
	[SerializeField] private Transform SpawnPosition;
	[SerializeField] private Text lifeCount;
	[SerializeField] private AudioSource explosionSound;

	private Animator planeAnimator;
	public static bool isDead;
	[Header("Prefabs do Rio")]
	public List<GameObject> riverSegmentPrefabs;
	
	void Start () {
		planeAnimator = GetComponent<Animator>();
	}
	
	void Update() {
		if(FuelController.noFuel){
			StartCoroutine(DeathCoolDown());
		}	
	}

	void OnCollisionEnter2D(Collision2D planeCollider){
		if(planeCollider.gameObject.CompareTag("BoxMapCollider")){
			Debug.Log("BoxMapCollider");
			GenerateNextSegment(); 
		}else{
			StartCoroutine(DeathCoolDown());
		}
	}
	void GenerateNextSegment() {
		float MapOffSetY = 10.49f;
		GameObject[] objects = GameObject.FindGameObjectsWithTag("Scenario");
		GameObject shortPosition = new GameObject();
		Debug.Log("objects: " + objects.Length);
		shortPosition.transform.position = new Vector3(0, int.MinValue, 0);
		foreach(GameObject obj in objects) {
			if (obj.transform.position.y > shortPosition.transform.position.y) {
            	shortPosition = obj;
        	}
		}
		Destroy(shortPosition);
		//GameObject nextSpawnPosition = GameObject.FindGameObjectWithTag("EndMap");
		Transform nextSpawnPosition = GameObject.FindGameObjectWithTag("Scenario").transform;
		Debug.Log("nextSpawnPosition: " + nextSpawnPosition.transform.position);

		int randomIndex = Random.Range(0, riverSegmentPrefabs.Count);
		GameObject selectedPrefab = riverSegmentPrefabs[randomIndex];

		GameObject newSegment = Instantiate(selectedPrefab, new Vector2(-4.349f,nextSpawnPosition.position.y + MapOffSetY), Quaternion.identity);
		
		Debug.Log("newSegment: " + newSegment.transform.position);
		//Destroy(nextSpawnPosition);
	}
	IEnumerator DeathCoolDown(){
		isDead = true;
		FuelController.noFuel = false;
		explosionSound.Play();
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
