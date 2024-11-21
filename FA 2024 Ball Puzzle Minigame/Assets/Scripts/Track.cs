using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public Transform lowerEndpoint;
    public Transform upperEndpoint;
    public GameObject objectOnTrack;
    public GameObject trackConnector;

    
    
    public void Start()
    {
        

    }
    public void Update()
    {
        
        CheckIfObjectIsOnTrack();
    }

   public void CheckIfObjectIsOnTrack()
    {
        if (lowerEndpoint.localPosition.y == upperEndpoint.transform.localPosition.y)
        {
            if (objectOnTrack.transform.localPosition.y != lowerEndpoint.transform.localPosition.y || 
                objectOnTrack.transform.localPosition.x < lowerEndpoint.transform.localPosition.x || 
                objectOnTrack.transform.localPosition.x > upperEndpoint.transform.localPosition.x)
            {
               objectOnTrack.transform.localPosition = new Vector3((upperEndpoint.localPosition.x + lowerEndpoint.localPosition.x) / 2, upperEndpoint.localPosition.y, 0f);
            }
        }

        if (lowerEndpoint.localPosition.x == upperEndpoint.transform.localPosition.x)
        {
            if (objectOnTrack.transform.localPosition.x != lowerEndpoint.transform.localPosition.x ||
                objectOnTrack.transform.localPosition.y < lowerEndpoint.transform.localPosition.y ||
                objectOnTrack.transform.localPosition.x > upperEndpoint.transform.localPosition.x)
            {
                objectOnTrack.transform.localPosition = new Vector3(upperEndpoint.localPosition.x, (upperEndpoint.localPosition.y + lowerEndpoint.localPosition.y) / 2,  0f);
            }
        }
    }
    
}
