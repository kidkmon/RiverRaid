using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	private GameObject plane;
	private Rigidbody2D enemyRb;

	[SerializeField] private float moveSpeed;
	[SerializeField] private float tempToDie;
	
	private float rangeLineHorizontal = 1f;
	private float rangeLineVertical = 0.7f;
	private float timeTemp;

	private bool planePassed;
	
	private int timesCollided = 1;

	void Start () {
		plane = GameObject.FindGameObjectWithTag("Player");
		enemyRb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

    	if (plane.transform.position.y > transform.position.y - rangeLineVertical){
			timeTemp += Time.deltaTime;
			if(timeTemp >= tempToDie){
				Destroy(gameObject);
			}
			else{
				enemyRb.velocity = new Vector2(moveSpeed, enemyRb.velocity.y);
			}	
		}

	}
	
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Player"){
			Destroy(gameObject);
		}
		else{
			transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, 1);
			if(timesCollided%2 == 0){
				transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, 1);
			}
			moveSpeed = -moveSpeed;
			timesCollided++;
		}
	}
}
