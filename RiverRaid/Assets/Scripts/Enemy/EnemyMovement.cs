using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	private GameObject plane;
	private Rigidbody2D enemyRb;

	private float rangeLineHorizontal = 1f;
	private float rangeLineVertical = 0.7f;
	[SerializeField] private float moveSpeed;

	[SerializeField] private bool toLeft; 
	private bool planePassed;

	void Start () {
		plane = GameObject.FindGameObjectWithTag("Player");
		enemyRb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		Debug.DrawLine(new Vector3(transform.position.x - rangeLineHorizontal, transform.position.y - rangeLineVertical, transform.position.z), new Vector3(transform.position.x + rangeLineHorizontal, transform.position.y - rangeLineVertical, transform.position.z));
        
        if (transform.localScale.x > 0 && plane.transform.position.y < transform.position.y && plane.transform.position.y > transform.position.y - rangeLineVertical){
			StartCoroutine(StartMoviment());	
        }

	}

	void OnCollisionEnter2D(Collision2D collision){
		toLeft = !toLeft;
		transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, 1);
		StartCoroutine(StartMoviment());
		
	}

	IEnumerator StartMoviment(){
		if(toLeft){
			moveSpeed = -moveSpeed;
		}
		enemyRb.velocity = new Vector2(moveSpeed, enemyRb.velocity.y);
		yield return new WaitForSeconds(0.125f);

	}
}
