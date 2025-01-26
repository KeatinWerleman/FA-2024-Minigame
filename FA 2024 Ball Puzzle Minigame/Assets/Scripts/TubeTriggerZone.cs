using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeTriggerZone : MonoBehaviour
{
    public List<Collider2D> collidersAroundTube;
    public List<Collider2D> mirrors;
    public List<Collider2D> affectedWalls;
   
    // Start is called before the first frame update
    void Start()
    {
        foreach (var collider in collidersAroundTube) 
        { 
            collider.enabled = false;
        }

        

       
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ENTERED TRIGGER ZONE");
        if (collision.gameObject.tag == "Ball")
        {

            foreach (var collider in collidersAroundTube) 
            { 
                if (collider.enabled)
                {
                    collider.enabled = false;
                    Debug.Log("DISABLED COLLIDERS");
                }
                else if (!collider.enabled)
                {
                    collider.enabled = true;
                    Debug.Log("ENABLED COLLIDERS");
                }
                
            }

            foreach(var collider in affectedWalls)
            {
                if (collider.enabled)
                {
                    collider.enabled = false;
                }
                else if (!collider.enabled)
                {
                    collider.enabled = true;
                }
            }

            foreach(var collider in mirrors)
            {
                if (collider.enabled)
                {
                    collider.enabled = false;
                }
                else if (!collider.enabled)
                {
                    collider.enabled = true;
                }
            }


            
        }
    }

    
}
