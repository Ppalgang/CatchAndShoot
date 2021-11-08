using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerController playerController;

    public GameObject ballSpawner;
    public GameObject ball;
    public GameObject angle;
    private Quaternion newballRotation;
    private Rigidbody ballRigid;
    public GameObject oldBall;

    private Camera cam;

    private float direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        rb.velocity = angle.transform.forward * 1 * 500 * Time.deltaTime;
        #region bilgisayar
        /*
        if (Input.GetMouseButtonDown(0))
        {
            playerController.enabled = false;
            newballRotation = angle.transform.rotation;
            Destroy(oldBall);
            GameObject new_ball = Instantiate(ball, ballSpawner.transform.position, newballRotation);
            new_ball.AddComponent<Rigidbody>();
            ballRigid = new_ball.GetComponent<Rigidbody>();

            cam.transform.SetParent(new_ball.transform);

            ballRigid.AddForce(angle.transform.forward * 700);
            ballRigid.AddForce(angle.transform.up * 350);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (direction < 30)
            {
                direction += 10f;
            }
            angle.transform.rotation = Quaternion.Slerp(angle.transform.rotation, Quaternion.Euler(0f, direction, 0f), Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (direction > -30)
            {
                direction += -10f;
            }
            angle.transform.rotation = Quaternion.Slerp(angle.transform.rotation, Quaternion.Euler(0f, direction, 0f), Time.deltaTime);
        }*/
        #endregion
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled && touch.phase != TouchPhase.Stationary && touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.x > 0)
                {
                    if (direction < 30)
                    {
                        direction += 10f;
                    }
                    angle.transform.rotation = Quaternion.Slerp(angle.transform.rotation, Quaternion.Euler(0f, direction, 0f), Time.deltaTime);
                }
                else if (touch.deltaPosition.x < 0)
                {
                    if (direction > -30)
                    {
                        direction += -10f;
                    }
                    angle.transform.rotation = Quaternion.Slerp(angle.transform.rotation, Quaternion.Euler(0f, direction, 0f), Time.deltaTime);
                }
                else
                {

                }
            }
            if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended && touch.phase != TouchPhase.Began)
            {
                playerController.enabled = false;
                newballRotation = angle.transform.rotation;
                Destroy(oldBall);
                GameObject new_ball = Instantiate(ball, ballSpawner.transform.position, newballRotation);
                new_ball.AddComponent<Rigidbody>();
                ballRigid = new_ball.GetComponent<Rigidbody>();

                cam.transform.SetParent(new_ball.transform);

                ballRigid.AddForce(angle.transform.forward * 700);
                ballRigid.AddForce(angle.transform.up * 350);
            }

        }


    }

}
