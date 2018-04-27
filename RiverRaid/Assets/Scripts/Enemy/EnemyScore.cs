using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScore : MonoBehaviour {

	[SerializeField] private int enemyValue;
	[SerializeField] private Text scoreText;

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet"){
			scoreText.text = (enemyValue + int.Parse(scoreText.text)).ToString();
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "Bullet"){
			scoreText.text = (enemyValue + int.Parse(scoreText.text)).ToString();
		}
	}
	
}
