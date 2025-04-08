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
    public float xOffset;
    public float yOffset;
    
    
    public void Start()
    {
        objectOnTrack.transform.position = new Vector3(Mathf.Round(transform.localPosition.x), Mathf.Round(transform.localPosition.y), transform.localPosition.z);
        

    }
    public void Update()
    {
        yOffset = Mathf.Abs(objectOnTrack.transform.localPosition.y - trackConnector.transform.localPosition.y);
        xOffset = Mathf.Abs(objectOnTrack.transform.localPosition.x - trackConnector.transform.localPosition.x);
        
            CheckIfObjectIsOnTrack();
    }
    public void CheckIfObjectIsOnTrack()
    {
        if (objectOnTrack != null)
        {
            if (lowerEndpoint.transform.localPosition.y == upperEndpoint.transform.localPosition.y)
            {
                if (yOffset > 0.05f ||
                    objectOnTrack.transform.localPosition.x > upperEndpoint.localPosition.x + 0.05f||
                    objectOnTrack.transform.localPosition.x < lowerEndpoint.localPosition.x - 0.05f)  
                {

                    objectOnTrack.transform.localPosition = new Vector3(Mathf.Round((upperEndpoint.localPosition.x + lowerEndpoint.localPosition.x) / 2), upperEndpoint.localPosition.y, 0f);
                }
            }

            else if (lowerEndpoint.transform.localPosition.x == upperEndpoint.transform.localPosition.x)
            {
                if (xOffset > 0.05f ||
                    objectOnTrack.transform.localPosition.y > upperEndpoint.localPosition.y + 0.05f ||
                    objectOnTrack.transform.localPosition.y < lowerEndpoint.localPosition.y - 0.05f)
                {
                    objectOnTrack.transform.localPosition = new Vector3(upperEndpoint.localPosition.x, (Mathf.Round((upperEndpoint.localPosition.y + lowerEndpoint.localPosition.y) / 2)), 0f);
                }
            }
        }
       
    }
    
}
