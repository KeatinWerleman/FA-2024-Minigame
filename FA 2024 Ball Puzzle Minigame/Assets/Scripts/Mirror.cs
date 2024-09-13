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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

    private void OnCollisionExit2D(Collision2D collision)
    {

        
        thisMirror.transform.position = new Vector3(Mathf.RoundToInt(thisMirror.transform.position.x), Mathf.RoundToInt(thisMirror.transform.position.y), 0f);
    }

}
