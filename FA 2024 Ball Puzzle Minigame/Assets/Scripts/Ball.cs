using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed;
    public Vector2 ballDirection;
    [SerializeField] Vector2 lastBallDirection;
    public Rigidbody2D ballRigidbody;
    public int delayFrames;
    
    
    
    
    
   

    private void Start()
    {
        ballRigidbody.velocity = new Vector2(BallLauncher.Instance.launchDirection.x, BallLauncher.Instance.launchDirection.y).normalized * ballSpeed;
        
        ballRigidbody = GetComponent<Rigidbody2D>();



}
    private void Update()
    {
        UnityEngine.Debug.Log("Ball Velocity:" + ballRigidbody.velocity);
        

    }

    private void LateUpdate()
    {
       // ballDirection = lastBallDirection;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 collisionNormal = collision.contacts[0].normal;
        ;
        ballDirection = Vector2.Reflect(ballRigidbody.velocity, collisionNormal).normalized;
        UnityEngine.Debug.Log("Ball Direction:" + ballDirection);
        ballRigidbody.velocity = new Vector2 (ballDirection.x, ballDirection.y) * ballSpeed;
        UnityEngine.Debug.Log("Ball Velocity:" + ballRigidbody.velocity);

        
    }

    
}
       
