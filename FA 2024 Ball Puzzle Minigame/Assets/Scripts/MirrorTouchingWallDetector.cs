using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorTouchingWallDetector : MonoBehaviour
{
    public GameObject thisMirror;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Launcher" || collision.gameObject.tag == "Target" || collision.gameObject.tag == "Switch" || collision.gameObject.tag == "Location Sprite")
        {
            Debug.Log("Touched Something Bad");
            Mouse.Instance.MoveBackToIntital(thisMirror);
        }
    }
}
