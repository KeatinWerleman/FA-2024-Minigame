using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeTriggerZone : MonoBehaviour
{
    public List<Collider2D> collidersAroundTube;
    public List<Collider2D> mirrors;
    public List<Collider2D> affectedWalls;
    public List<GameObject> triggerZones;
    public bool isBallInTube;

   
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
        if (collision.gameObject.tag == "Ball" || collision.gameObject.tag == "Special Ball")
        {

            if (isBallInTube == true)
            {
                isBallInTube = false;
                foreach(var collider in triggerZones)
                {
                    gameObject.GetComponent<TubeTriggerZone>().isBallInTube = false;
                }
            }

            else if (isBallInTube == false)
            {
                isBallInTube = true;
                foreach (var collider in triggerZones)
                {
                    gameObject.GetComponent<TubeTriggerZone>().isBallInTube = true;
                }
            }
            HandleColliders();

            
        }
    }

    public void HandleColliders()
    {
        if (!isBallInTube)
        {
            foreach (var collider in collidersAroundTube)
            {
                collider.enabled = false;
                Debug.Log("TUBE COLLIDERS OFF");
            }

            foreach (var collider in affectedWalls)
            {

                collider.enabled = true;
                Debug.Log("WALL COLLIDERS ON");
            }

            foreach (var collider in mirrors)
            {
                collider.enabled = true;
                Debug.Log("MIRROR COLLIDERS ON");
            }
        }

        if (isBallInTube)
        {
            foreach (var collider in collidersAroundTube)
            {

                collider.enabled = true;
                Debug.Log("TUBE COLLIDERS ON");
            }

            foreach (var collider in affectedWalls)
            {
                collider.enabled = false;
                Debug.Log("WALL COLLIDERS ON");
            }

            foreach (var collider in mirrors)
            {

                collider.enabled = false;
                Debug.Log("MIRROR COLLIDERS OFF");
            }
        }
    }
    
}
