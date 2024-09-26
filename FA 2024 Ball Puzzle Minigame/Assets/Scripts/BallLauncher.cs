using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public GameObject ballPrefab;
    public float launchSpeed;
    public GameObject ballSpawnPoint;
    bool canLaunchBall = true;
    public int availibleBalls;
    public List<GameObject> ballsInPlay;
    public Vector3 launchDirection;
    public TextMeshProUGUI ballsLeftText;
    
  

    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (availibleBalls > 0)
            {
                LaunchBall();
            }   
        }

    }
    void LaunchBall()
    {

        if (ballsInPlay.Count > 0)
        {
            Destroy(ballsInPlay[0]);
            ballsInPlay.RemoveAt(0);
        }
        GameManager.Instance.TurnLaunchStateOff();
        GameObject newBall = Instantiate(ballPrefab, ballSpawnPoint.transform.position, Quaternion.identity);
        ballsInPlay.Add(newBall);
        newBall.GetComponent<Rigidbody2D>().AddForce(ballSpawnPoint.transform.localPosition * launchSpeed);
        availibleBalls -= 1;
        ballsLeftText.SetText(availibleBalls.ToString());
        Debug.Log("Ball Launched /n Balls Remaining: " + availibleBalls);
        
    }


}
