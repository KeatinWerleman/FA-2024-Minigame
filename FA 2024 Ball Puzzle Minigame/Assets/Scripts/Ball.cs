using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed;
    public Vector2 ballDirection;
    
    
    public Rigidbody2D ballRigidbody;
    public Collider ballCollider;
    
    
   

    private void Start()
    {
        ballDirection = new Vector2(BallLauncher.Instance.launchDirection.x, BallLauncher.Instance.launchDirection.y);
        ballRigidbody = GetComponent<Rigidbody2D>();
        ballCollider = GetComponent<Collider>();
        
        
}
    private void Update()
    {
        transform.position += new Vector3(ballDirection.x, ballDirection.y, 0f) * ballSpeed * Time.deltaTime;
        transform.rotation = Quaternion.identity;
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var firstContact = collision.contacts[0];
        
        ballDirection = Vector2.Reflect(ballDirection.normalized, firstContact.normal);
        ballDirection = new Vector2(Mathf.Round(ballDirection.x), Mathf.Round(ballDirection.y));
        

    }



    



}
