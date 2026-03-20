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
    
    public float launchSpeed;
    public Transform ballSpawnPoint;
    
    
    public Color ballColor;
    public List<GameObject> ballsInPlay;
    public Vector2 launchDirection;
    public bool isInOriginalLocation;
    public GameObject undoButton;
   
    public AudioClip ballLaunchClip;
    public GameObject ballLaunchParticleSystem;

    
    
    
    
    public float volume;
    public static BallLauncher Instance;
    public bool isLaunchedBySwitch;
    public SpriteRenderer spriteRenderer;
    public List<GameObject> tubeTriggerZones;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

        
        isInOriginalLocation = true;
        spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject[] tubeTriggers = GameObject.FindGameObjectsWithTag("Tube Endpoint");
        if (tubeTriggers.Length > 0)
        {
            tubeTriggerZones = new List<GameObject>();

            foreach (GameObject tubeTrigger in tubeTriggers)
            {

                tubeTriggerZones.Add(tubeTrigger);

            }
        }
    }
    void Update()
    {
        volume = PlayerPrefs.GetFloat("Sound Effects Volume");
        if (!isLaunchedBySwitch)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {

                
                
                    LaunchBall();
                
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                
                    LaunchSpecialBall();
                
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ClearField();
        }
    }
    public void LaunchBall()
    {

        if (ballsInPlay.Count > 0)
        {
            Destroy(ballsInPlay[0]);
            ballsInPlay.RemoveAt(0);
            
        }
        
        
        if (tubeTriggerZones != null && tubeTriggerZones.Count > 0)
        {
            foreach (GameObject tubeTrigger in tubeTriggerZones)
            {
                tubeTrigger.GetComponent<TubeTriggerZone>().isBallInTube = false;
            }

        }
        GameManager.Instance.TurnLaunchStateOff();
        SoundFXManager.Instance.PlaySoundFXClip(ballLaunchClip, transform, volume);
        ParticleSystem.MainModule main = ballLaunchParticleSystem.GetComponent<ParticleSystem>().main;
        main.startColor = spriteRenderer.color;
            
        GameObject newBall = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
        newBall.GetComponent<Rigidbody2D>().AddForce(launchDirection * launchSpeed);
        newBall.GetComponent<SpriteRenderer>().color = ballColor;
        GameManager.Instance.UpdateScore(3);
        undoButton.SetActive(true);
        ballsInPlay.Add(newBall);
        

        
        if (PlayerPrefs.GetString("Are Particles On") == "true")
        {
            var particles = Instantiate(ballLaunchParticleSystem, ballSpawnPoint.transform.position, ballSpawnPoint.rotation);
            Destroy(particles, 0.5f);
        }
        // Debug.Log("Ball Launched /n Balls Remaining: " + availibleBalls);
            
        
    }

    public void LaunchSpecialBall()
    {
        if (ballsInPlay.Count > 0)
        {
            Destroy(ballsInPlay[0]);
            ballsInPlay.RemoveAt(0);

        }
        
        
        if (tubeTriggerZones != null && tubeTriggerZones.Count > 0)
        {
            foreach (GameObject tubeTrigger in tubeTriggerZones)
            {
                tubeTrigger.GetComponent<TubeTriggerZone>().isBallInTube = false;
            }

        }
        GameManager.Instance.TurnLaunchStateOff();
        
        SoundFXManager.Instance.PlaySoundFXClip(ballLaunchClip, transform, volume);
        ParticleSystem.MainModule main = ballLaunchParticleSystem.GetComponent<ParticleSystem>().main;
        main.startColor = spriteRenderer.color;
        var particles = Instantiate(ballLaunchParticleSystem, ballSpawnPoint.transform.position, ballSpawnPoint.rotation);
        GameObject newBall = Instantiate(specialBallPrefab, ballSpawnPoint.position, Quaternion.identity);
        newBall.GetComponent<Rigidbody2D>().AddForce(launchDirection * launchSpeed);
        newBall.GetComponent<SpriteRenderer>().color = ballColor;
        GameManager.Instance.UpdateScore(5);
        undoButton.SetActive(true);
        ballsInPlay.Add(newBall);
            
            
            
            Destroy(particles, 0.5f);
        
    }

    public void ClearField()
    {
        if (ballsInPlay.Count > 0)
        {
            Destroy(ballsInPlay[0]);
            undoButton.SetActive(false);
            ballsInPlay.RemoveAt(0);
        }
        
    }
}
