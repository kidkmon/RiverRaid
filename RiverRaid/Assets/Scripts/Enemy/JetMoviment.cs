using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetMoviment : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] private float rangeLineVertical;
	
	[SerializeField] private GameObject plane;
	private Rigidbody2D jetRb;
	private Animator jetAnimator;

	private bool enemyGotHit;
	
	void Start () {
		jetRb = GetComponent<Rigidbody2D>();
		jetAnimator = GetComponent<Animator>();
	}

	void Update () {

		if(plane.activeSelf){
			if (plane.transform.position.y > transform.position.y - rangeLineVertical && !enemyGotHit){
				jetRb.velocity = new Vector2(moveSpeed, jetRb.velocity.y);
			}
		}

	}

	void OnCollisionEnter2D(Collision2D collision){
	
		if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet"){
			enemyGotHit = true;
			StartCoroutine(DeathAnimation());
		}
		if(collision.gameObject.tag == "Untagged"){
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
		}
	}

	IEnumerator DeathAnimation(){
		GetComponent<AudioSource>().Play();
		jetRb.velocity = new Vector2(0, 0);
		GetComponent<BoxCollider2D>().enabled = false;
		jetAnimator.SetBool("isDead", true);
		yield return new WaitForSeconds(0.8f);
		jetAnimator.SetBool("isDead", false);
		GetComponent<BoxCollider2D>().enabled = true;
		enemyGotHit = false;
		gameObject.SetActive(false);
	}
}
