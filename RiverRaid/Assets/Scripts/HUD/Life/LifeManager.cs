using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {

	[SerializeField] private Text lifeCount;
	[SerializeField] private Text scoreText;
	
	private int scoreForNextExtraLife = 10000;
	private string sceneName;

	void Start(){
		sceneName = SceneManager.GetActiveScene().name;
	}

	void Update () {
		if(int.Parse(scoreText.text) >= scoreForNextExtraLife ){
			scoreForNextExtraLife = scoreForNextExtraLife + 10000;
			lifeCount.text = (int.Parse(lifeCount.text) + 1).ToString();
		}

		if(lifeCount.text == "" && PlaneRaycast.isDead){
			if(Input.GetKeyDown(KeyCode.Space)){
				Time.timeScale = 1f;
				SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
				PlaneRaycast.isDead = false;
			}
		}
	}

}
