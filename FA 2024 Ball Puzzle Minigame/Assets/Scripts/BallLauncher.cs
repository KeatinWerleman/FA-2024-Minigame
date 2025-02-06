using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BallLauncher : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject specialBallPrefab;
    public int specialBallCount;
    public TextMeshProUGUI specialBallLaunchButtonText;
    public float launchSpeed;
    public Transform ballSpawnPoint;
    public int maxAvailibleBalls;
    public int availibleBalls;
    public Color ballColor;
    public List<GameObject> ballsInPlay;
    public Vector2 launchDirection;
    
    public bool isInOriginalLocation;
    public TextMeshProUGUI ballsLeftText;
    public AudioClip ballLaunchClip;
    public GameObject ballLaunchParticleSystem;
    
    
    
    
    public float volume;
    public static BallLauncher Instance;
    public bool isLaunchedBySwitch;
    public SpriteRenderer spriteRenderer;
    public GameObject tubeTriggerZone;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
        ballsLeftText.SetText(availibleBalls.ToString());
        availibleBalls = maxAvailibleBalls;
        isInOriginalLocation = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        


    }
    void Update()
    {
        
        if (!isLaunchedBySwitch)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {

                if (availibleBalls > 0)
                {
                    LaunchBall();
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (availibleBalls > 0 && specialBallCount >0)
                {
                    LaunchSpecialBall();
                }
            }
        }

        

        

        

    }
    public void LaunchBall()
    {

        if (ballsInPlay.Count > 0)
        {
            Destroy(ballsInPlay[0]);
            ballsInPlay.RemoveAt(0);
            if (tubeTriggerZone != null)
            {
                tubeTriggerZone.GetComponent<TubeTriggerZone>().isBallInTube = false;

            }
        }
        if (availibleBalls > 0)
        {
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

        
        
    }

    public void LaunchSpecialBall()
    {
        if (ballsInPlay.Count > 0)
        {
            Destroy(ballsInPlay[0]);
            ballsInPlay.RemoveAt(0);
        }
        if (specialBallCount > 0 && availibleBalls > 0)
        {
            GameManager.Instance.TurnLaunchStateOff();
            SoundFXManager.Instance.PlaySoundFXClip(ballLaunchClip, transform, volume);
            ParticleSystem.MainModule main = ballLaunchParticleSystem.GetComponent<ParticleSystem>().main;
            main.startColor = spriteRenderer.color;
            var particles = Instantiate(ballLaunchParticleSystem, ballSpawnPoint.transform.position, ballSpawnPoint.rotation);
            GameObject newBall = Instantiate(specialBallPrefab, ballSpawnPoint.position, Quaternion.identity);
            newBall.GetComponent<Rigidbody2D>().AddForce(launchDirection * launchSpeed);
            newBall.GetComponent<SpriteRenderer>().color = ballColor;
            ballsInPlay.Add(newBall);
            availibleBalls -= 1;
            specialBallCount -= 1;
            ballsLeftText.SetText(availibleBalls.ToString());
            specialBallLaunchButtonText.SetText("Launch Powerball (" + specialBallCount.ToString() + ")");
            Debug.Log("Ball Launched /n Balls Remaining: " + availibleBalls);
            Destroy(particles, 0.5f);
        }

        

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
