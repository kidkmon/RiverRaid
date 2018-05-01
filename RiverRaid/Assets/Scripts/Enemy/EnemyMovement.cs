using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] private float rangeLineVertical;
	
	[SerializeField] private GameObject plane;
	private Rigidbody2D enemyRb;
	private Animator enemyAnimator;
	
	private bool enemyGotHit;
	private int timesCollided = 1;

	void Start () {
		enemyRb = GetComponent<Rigidbody2D>();
		enemyAnimator = GetComponent<Animator>();
	}
	
	void Update () {

		if(plane.activeSelf){
			if ((plane.transform.position.y > transform.position.y - rangeLineVertical) && !enemyGotHit){
				enemyRb.velocity = new Vector2(moveSpeed, enemyRb.velocity.y);	
			}
		}

	}
	
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet"){
			enemyGotHit = true;
			StartCoroutine(DeathAnimation());
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

	IEnumerator DeathAnimation(){
		GetComponent<AudioSource>().Play();
		enemyRb.velocity = new Vector2(0, 0);
		GetComponent<BoxCollider2D>().enabled = false;
		enemyAnimator.SetBool("isDead", true);
		yield return new WaitForSeconds(0.8f);
		enemyAnimator.SetBool("isDead", false);
		GetComponent<BoxCollider2D>().enabled = true;
		enemyGotHit = false;
		gameObject.SetActive(false);
	}
}
