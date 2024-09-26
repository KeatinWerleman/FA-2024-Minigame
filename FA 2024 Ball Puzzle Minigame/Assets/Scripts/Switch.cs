using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject affectedObject;
    public bool isSwitchActive = false;
    public Vector3 positionA;
    public Vector3 rotationA;
    public Vector3 positionB;
    public Vector3 rotationB;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (isSwitchActive == false)
            {
                affectedObject.transform.position = new Vector3(positionB.x, positionB.y, 0f);
                affectedObject.transform.rotation = new Quaternion(rotationB.x, rotationB.y, rotationB.z, 0f);
                Destroy(collision.gameObject);
                isSwitchActive = true;
            }

            else if (isSwitchActive == true)
            {
                affectedObject.transform.position = new Vector3(positionA.x, positionA.y, 0f);
                affectedObject.transform.rotation = new Quaternion(rotationA.x, rotationA.y, rotationA.z, 0f);
                Destroy(collision.gameObject);
                isSwitchActive = false;
            }
            
        }
    }
}
