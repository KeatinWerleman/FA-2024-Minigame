using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Mouse : MonoBehaviour
{
    public GameObject selectedObject;
    Vector3 offset;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            if (targetObject.tag == "Mirror")
            {
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
            }

        }

        if (selectedObject)
        {
            
            selectedObject.transform.position = mousePosition + offset;
            
        }

        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            
            selectedObject.transform.position = new Vector3(Mathf.RoundToInt(selectedObject.transform.position.x), Mathf.RoundToInt(selectedObject.transform.position.y), 0f);
            /*if (selectedObject.transform.position.x % 2 != 0f || selectedObject.transform.position.y != 0f)
            
            



            }*/
            selectedObject = null;
        }
    }
}
