using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour {

    [SerializeField] private float fuelDecreaseStep;
    [SerializeField] private float decreaseInterval;
    [SerializeField] private float minFuelX;
    [SerializeField] private float warningX;

    private float timeTemp;
    private AudioSource audioSource;

    public static bool noFuel;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (CameraStart.gameStarted && !PlaneRaycast.isDead)
        {
            if (transform.position.x > minFuelX)
            {
                timeTemp += Time.deltaTime;
                if (timeTemp > decreaseInterval)
                {
                    if (transform.position.x < warningX && !audioSource.isPlaying)
                    {
                        audioSource.Play();
                    }
                    transform.position = new Vector3(transform.position.x - fuelDecreaseStep, transform.position.y, transform.position.z);
					Debug.Log("Fuel Decreased: " + transform.position.x + " at time: " + fuelDecreaseStep);
                    timeTemp = 0;
                }
            }
            else
            {
                noFuel = true;
            }
        }
        if (!CameraStart.gameStarted)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }

}
