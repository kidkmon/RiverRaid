using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    [SerializeField] private float bulletSpeed;
    private Rigidbody2D bulletRb;

	void Start () {

        bulletRb = GetComponent<Rigidbody2D>();
	
	}

	void Update () {

        bulletRb.velocity = new Vector2(bulletRb.velocity.x, bulletSpeed * Time.deltaTime);

	}

	void OnCollisionEnter2D(Collision2D collision){
		Destroy(gameObject);
	}

}