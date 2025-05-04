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
			Debug.Log(planeCollider.gameObject.name);
			// StartCoroutine(DeathCoolDown());
		}
	}
	void GenerateNextSegment() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag("Scenario");
		if (objects.Length == 0) {
			Debug.LogError("Nenhum objeto com a tag 'Scenario' foi encontrado!");
			return;
		}

		// Encontre o segmento com a maior posição Y
		GameObject highestSegment = null;
		float highestY = float.MinValue;

		foreach (GameObject obj in objects) {
			if (obj.transform.position.y > highestY) {
				highestY = obj.transform.position.y;
				highestSegment = obj;
			}
		}

		if (highestSegment == null) {
			Debug.LogError("Não foi possível determinar o segmento com a maior posição Y.");
			return;
		}

		Debug.Log("Segmento mais alto encontrado em: " + highestSegment.transform.position);

		// Gere o próximo segmento
		int randomIndex = Random.Range(0, riverSegmentPrefabs.Count);
		GameObject selectedPrefab = riverSegmentPrefabs[randomIndex];

		GameObject newSegment = Instantiate(
			selectedPrefab,
			new Vector2(highestSegment.transform.position.x, highestSegment.transform.position.y),
			Quaternion.identity
		);

		Debug.Log("Novo segmento gerado em: " + newSegment.transform.position);
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
