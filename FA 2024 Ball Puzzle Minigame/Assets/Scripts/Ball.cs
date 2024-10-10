using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed;
    public Vector2 ballDirection;
    public string winTag;

  /*  private void Update()
    {
        ballDirection = new Vector2(1, 0).normalized;
        transform.position += (Vector3)ballDirection * ballSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 surfaceNormal = collision.contacts[0].normal;
        ballDirection = Vector2.Reflect(ballDirection, surfaceNormal);
    }

    */



}
