using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Track : MonoBehaviour
{
    public Transform lowerEndpoint;
    public Transform upperEndpoint;
    public GameObject objectOnTrack;
    public GameObject trackConnector;
    public bool isObjectThere = true;
    
    
    public void Start()
    {
        objectOnTrack.transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), transform.position.z);

    }
    public void Update()
    {
        CheckIfObjectIsOnTrack();
        


    }

    
   public void CheckIfObjectIsOnTrack()
    {
        if (objectOnTrack != null)
        {
            if (lowerEndpoint.localPosition.y == upperEndpoint.transform.localPosition.y)
            {
                if (objectOnTrack.transform.localPosition.y != lowerEndpoint.transform.localPosition.y ||
                    objectOnTrack.transform.localPosition.x < lowerEndpoint.transform.localPosition.x ||
                    objectOnTrack.transform.localPosition.x > upperEndpoint.transform.localPosition.x)
                {
                    objectOnTrack.transform.localPosition = new Vector3(Mathf.Round(upperEndpoint.localPosition.x + lowerEndpoint.localPosition.x) / 2, upperEndpoint.localPosition.y, 0f);
                }
            }

            else if (lowerEndpoint.localPosition.x == upperEndpoint.transform.localPosition.x)
            {
                if (objectOnTrack.transform.localPosition.x != lowerEndpoint.transform.localPosition.x ||
                    objectOnTrack.transform.localPosition.y < lowerEndpoint.transform.localPosition.y ||
                    objectOnTrack.transform.localPosition.y > upperEndpoint.transform.localPosition.y)
                {
                    objectOnTrack.transform.localPosition = new Vector3(upperEndpoint.localPosition.x, (Mathf.Round(upperEndpoint.localPosition.y + lowerEndpoint.localPosition.y) / 2), 0f);
                }
            }
        }
       
    }
    
}
