using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public int hitCount;
    public int maxHitCount;
    public GameObject thisMirror;
    public string wallTag;
    public string shooterTag;
    public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Mirror Inside Wall");
            Mouse.Instance.MoveBackToIntital(thisMirror);
        }
    }

}
