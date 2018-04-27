using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetMoviment : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] private float tempToDie;
	[SerializeField] private float rangeLineVertical;
	
	private GameObject plane;
	private Rigidbody2D jetRb;
	private Animator jetAnimator;

	private float timeTemp;
	private bool enemyGotHit;
	
	void Start () {
		plane = GameObject.FindGameObjectWithTag("Player");
		jetRb = GetComponent<Rigidbody2D>();
		jetAnimator = GetComponent<Animator>();
	}

	void Update () {

    	if (plane.transform.position.y > transform.position.y - rangeLineVertical && !enemyGotHit){
			timeTemp += Time.deltaTime;
			if(timeTemp >= tempToDie){
				StartCoroutine(DeathAnimation());
			}
			else{
				jetRb.velocity = new Vector2(moveSpeed, jetRb.velocity.y);
			}	
		}

	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Player"){
			enemyGotHit = true;
			StartCoroutine(DeathAnimation());
		}
		if(collision.gameObject.tag == "Untagged"){
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
		}
	}

	IEnumerator DeathAnimation(){
		jetRb.velocity = new Vector2(0, 0);
		GetComponent<BoxCollider2D>().enabled = false;
		jetAnimator.SetBool("isShortDead", true);
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}
}
