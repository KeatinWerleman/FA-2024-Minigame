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
    public Color ballColor;
    public List<GameObject> ballsInPlay;
    public Vector3 launchDirection;
    public TextMeshProUGUI ballsLeftText;
    public AudioClip ballLaunchClip;
    public GameObject ballLaunchParticleSystem;
    
    
    
    public float volume;
    public static BallLauncher Instance;
    public bool isLaunchedBySwitch;
    public SpriteRenderer spriteRenderer;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ballsLeftText.SetText(availibleBalls.ToString());
        availibleBalls = maxAvailibleBalls;

        spriteRenderer = GetComponent<SpriteRenderer>();
        


    }
    void Update()
    {
        
        if (!isLaunchedBySwitch)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (availibleBalls > 0)
                {
                    LaunchBall();
                }
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
        SoundFXManager.Instance.PlaySoundFXClip(ballLaunchClip, transform, volume);
        ParticleSystem.MainModule main = ballLaunchParticleSystem.GetComponent<ParticleSystem>().main;
        main.startColor = spriteRenderer.color;
        var particles = Instantiate(ballLaunchParticleSystem, ballSpawnPoint.transform.position, ballSpawnPoint.rotation);
        GameObject newBall = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
        newBall.GetComponent<Rigidbody2D>().AddForce(launchDirection * launchSpeed);
        newBall.GetComponent<SpriteRenderer>().color = ballColor;
        ballsInPlay.Add(newBall);
        availibleBalls -= 1;
        ballsLeftText.SetText(availibleBalls.ToString());
        
        Debug.Log("Ball Launched /n Balls Remaining: " + availibleBalls);
        Destroy(particles, 0.5f);
        
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
