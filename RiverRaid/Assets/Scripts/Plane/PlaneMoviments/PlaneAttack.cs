using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAttack : MonoBehaviour{

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private AudioSource bulletSong;

    private float timeTemp;
    private float bulletCoolDownHolding = 0.5f;
    private float bulletCoolDown = 0.4f;

    private bool isPressed;

    void Update(){
        
        if(!PlaneRaycast.isDead){
            if(Input.GetKeyDown(KeyCode.Space) && !isPressed){
                isPressed = true;
                bulletSong.Play();
                Instantiate(bullet, bulletTransform.position, bulletTransform.rotation);
                StartCoroutine(BulletCoolDown());
            }

            if(Input.GetKey(KeyCode.Space) && !isPressed){
                timeTemp += Time.deltaTime;
                if(timeTemp >= bulletCoolDownHolding){
                    bulletSong.Play();
                    Instantiate(bullet, bulletTransform.position, bulletTransform.rotation);
                    timeTemp = 0;
                }            
            }
        }
    }

    IEnumerator BulletCoolDown(){
        yield return new WaitForSeconds(bulletCoolDown);
        isPressed = false;
    }
}
