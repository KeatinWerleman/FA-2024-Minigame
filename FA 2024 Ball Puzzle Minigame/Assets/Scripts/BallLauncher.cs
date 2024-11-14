using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public GameObject ballPrefab;
    public float launchSpeed;
    public Transform ballSpawnPoint;
    public int maxAvailibleBalls;
    public int availibleBalls;
    public List<GameObject> ballsInPlay;
    public Vector3 launchDirection;
    public TextMeshProUGUI ballsLeftText;
    public AudioClip ballLaunchClip;
    public static BallLauncher Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ballsLeftText.SetText(availibleBalls.ToString());
        availibleBalls = maxAvailibleBalls;
    }
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (availibleBalls > 0)
            {
                LaunchBall();
            }   
        }

        if (Input.GetKeyDown(KeyCode.W)) 
        {

            ClearField();
           
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
        SoundFXManager.Instance.PlaySoundFXClip(ballLaunchClip, transform, 1f);
        GameObject newBall = Instantiate(ballPrefab, ballSpawnPoint.position, transform.rotation);
        newBall.GetComponent<Rigidbody2D>().AddForce(launchDirection * 150);
        ballsInPlay.Add(newBall);
        availibleBalls -= 1;
        ballsLeftText.SetText(availibleBalls.ToString());
        Debug.Log("Ball Launched /n Balls Remaining: " + availibleBalls);
        
    }

    public void ClearField()
    {
        if (ballsInPlay.Count > 0)
        {
            Destroy(ballsInPlay[0]);
            ballsInPlay.RemoveAt(0);
        }
        
    }


}
