using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeTriggerZone : MonoBehaviour
{
    public List<Collider2D> cornerColliders;
    public List<Collider2D> mirrors;
    public Collider2D affectedWalls;
    public List<GameObject> triggerZones;
    public bool isBallInTube;
    

    // Start is called before the first frame update
    void Start()
    {
        
        foreach (var collider in cornerColliders) 
        { 
            collider.enabled = false;
        }

        List<GameObject> mirrorObjects = new List<GameObject>();
        mirrorObjects.AddRange(GameObject.FindGameObjectsWithTag("Mirror"));
        foreach (var mirrorObject in mirrorObjects)
        {
            Collider2D mirrorCollider = mirrorObject.GetComponent<Collider2D>();
            mirrors.Add(mirrorCollider);
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
                    collider.gameObject.GetComponent<TubeTriggerZone>().isBallInTube = false;
                    Debug.Log("Ball in Tube");


             
                }
                collision.gameObject.GetComponent<Ball>().ballSpeed = 5;
            }

            else if (isBallInTube == false)
            {
                isBallInTube = true;
                foreach (var collider in triggerZones)
                {
                    collider.gameObject.GetComponent<TubeTriggerZone>().isBallInTube = true;
                }
                collision.gameObject.GetComponent<Ball>().ballSpeed = 10;
            }
            HandleColliders();

            
        }
    }

    public void HandleColliders()
    {
        if (!isBallInTube)
        {
            foreach (var collider in cornerColliders)
            {
                collider.enabled = false;
                Debug.Log("TUBE COLLIDERS OFF");
            }

           
            

                affectedWalls.enabled = true;
                Debug.Log("WALL COLLIDERS ON");
            

            foreach (var collider in mirrors)
            {
                collider.enabled = true;
                Debug.Log("MIRROR COLLIDERS ON");
            }
        }

        if (isBallInTube)
        {
            foreach (var collider in cornerColliders)
            {

                collider.enabled = true;
                Debug.Log("TUBE COLLIDERS ON");
            }

            affectedWalls.enabled = false;

            foreach (var collider in mirrors)
            {

                collider.enabled = false;
                Debug.Log("MIRROR COLLIDERS OFF");
            }
        }
    }
    
}
