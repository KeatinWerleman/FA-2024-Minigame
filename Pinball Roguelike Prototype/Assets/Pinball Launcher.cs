using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballLauncher : MonoBehaviour
{
    public Transform launchingPosition;
    public GameObject ballPrefab;
    public float launchForce;
    public float launchForceIncreaseRate;
    [SerializeField] float minLaunchForce;
    
    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            launchForce += launchForceIncreaseRate;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            LaunchBall();
        }
    }

    public void LaunchBall()
    {
        GameObject ball = Instantiate(ballPrefab, launchingPosition);
        Rigidbody2D ballRigidbody = ball.GetComponent<Rigidbody2D>();
        
        ballRigidbody.AddForce(new Vector2(0,1) * launchForce);
        launchForce = minLaunchForce;

    }
}
