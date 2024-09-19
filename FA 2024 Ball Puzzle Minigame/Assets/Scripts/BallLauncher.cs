using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public GameObject ballPrefab;
    public float launchSpeed;
    public GameObject ballSpawnPoint;
    bool canLaunchBall = true;
    public int availibleBalls;
  

    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.Space) && canLaunchBall == true )
        {
            LaunchBall();
            
        }

    }
    void LaunchBall()
    {
        // if all mirrors are aligned, launch ball
        GameObject newBall = Instantiate(ballPrefab, ballSpawnPoint.transform.position, ballSpawnPoint.transform.rotation);
        newBall.GetComponent<Rigidbody2D>().AddForce(ballSpawnPoint.transform.localPosition * launchSpeed);
        availibleBalls -= 1;
        Debug.Log("Ball Launched/n Balls Remaining: " + availibleBalls);
    }
}
