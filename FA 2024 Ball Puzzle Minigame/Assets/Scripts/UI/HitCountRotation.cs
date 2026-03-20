using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitCountRotation : MonoBehaviour
{
    public RectTransform rectTransform;
    public Transform parentMirrorTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float myTargetRotationZ = -(parentMirrorTransform.transform.rotation.z); //get the X rotation from anotherObject
        float myTargetRotationY = rectTransform.rotation.y; //get the Y rotation from this object
        float myTargetRotationX = rectTransform.rotation.x; //get the Z rotation from this object
        Vector3 myEulerAngleRotation = new Vector3(myTargetRotationX, myTargetRotationY, myTargetRotationZ);
        rectTransform.rotation = Quaternion.Euler(myEulerAngleRotation);
        
    }
}
