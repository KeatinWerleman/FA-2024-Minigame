using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Mirror : MonoBehaviour
{
    public int hitCount;
    public int maxHitCount;
    public GameObject thisMirror;
    public string wallTag;
    public string shooterTag;
    public TextMeshPro hitCountText;
    
    // Start is called before the first frame update
    void Start()
    {
        
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            hitCount--;
            hitCountText.SetText(hitCount.ToString());
            Debug.Log(collision.gameObject.transform.position);
        }

        if (hitCount <= 0)
        {
            Destroy(thisMirror);
        }
    }

}
