using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class UpdateTrackLength : MonoBehaviour
{
    public Transform lowerEndpoint;
    public Transform upperEndpoint;
    public GameObject objectOnTrack;
    public GameObject trackConnector;
    public float trackScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            UpdateTrack();
        }
        
    }
    public void UpdateTrack()
    {
       
        if (lowerEndpoint.localPosition.y == upperEndpoint.transform.localPosition.y)
        {
            
            trackScale = upperEndpoint.localPosition.x - lowerEndpoint.localPosition.x;
            trackScale = Mathf.Abs(trackScale);

            trackConnector.transform.localPosition = new Vector3((upperEndpoint.localPosition.x + lowerEndpoint.localPosition.x) / 2, upperEndpoint.localPosition.y, 0f);
            trackConnector.transform.localScale = new Vector3(trackScale, trackConnector.transform.localScale.y, trackConnector.transform.localScale.z);

            objectOnTrack.transform.localPosition = new Vector3((upperEndpoint.localPosition.x + lowerEndpoint.localPosition.x) / 2, upperEndpoint.localPosition.y, 0f);

            upperEndpoint.transform.localPosition = new Vector3(lowerEndpoint.localPosition.x + trackScale, upperEndpoint.transform.localPosition.y, 0f);
            lowerEndpoint.transform.localPosition = new Vector3(upperEndpoint.localPosition.x - trackScale, lowerEndpoint.transform.localPosition.y, 0f);
            
            
        }

        if (lowerEndpoint.localPosition.x == upperEndpoint.transform.localPosition.x)
        {
            
            trackScale = upperEndpoint.localPosition.y - lowerEndpoint.localPosition.y;
            trackScale = Mathf.Abs(trackScale);

            trackConnector.transform.localPosition = new Vector3(upperEndpoint.localPosition.x, (upperEndpoint.localPosition.y + lowerEndpoint.localPosition.y) / 2, 0f);
            trackConnector.transform.localScale = new Vector3(trackConnector.transform.localScale.x, trackScale, trackConnector.transform.localScale.z);

            objectOnTrack.transform.localPosition = new Vector3(upperEndpoint.localPosition.x, (upperEndpoint.localPosition.y + lowerEndpoint.localPosition.y) / 2, 0f);

            upperEndpoint.transform.localPosition = new Vector3(upperEndpoint.transform.localPosition.x, lowerEndpoint.localPosition.y + trackScale, 0f);
            lowerEndpoint.transform.localPosition = new Vector3(lowerEndpoint.transform.localPosition.x, upperEndpoint.localPosition.y - trackScale, 0f);
            
        }
    }

}
