using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject oldCamera;
    public GameObject newCamera;
    public PlayerController oldPlayer;
    public PlayerController newPlayer;
    public GameObject newBall;
    public GameObject newAngle;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(oldCamera);
        newCamera.SetActive(true);

        Destroy(oldPlayer);
        newPlayer.enabled = true;

        Destroy(gameObject);
        newBall.SetActive(true);
        newAngle.SetActive(true);

    }
}
