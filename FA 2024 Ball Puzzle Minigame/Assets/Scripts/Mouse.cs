using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Mouse : MonoBehaviour
{
    public static Mouse Instance;

    private void Awake()
    {
        Instance = this;
    }
    public GameObject selectedObject;
    Vector3 offset;
    public AudioClip pickUpSound;
    public AudioClip putDownSound;
    public float volume = 0.5f;
    public Vector3 initialPosition;

    
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            
            if (targetObject == null)
            {
                Debug.Log("touched nothing");
            }
            if (targetObject.tag == "Mirror")
            {

                selectedObject = targetObject.transform.gameObject;

                SoundFXManager.Instance.PlaySoundFXClip(pickUpSound, transform, volume);
                initialPosition = selectedObject.transform.position;

                offset = selectedObject.transform.position - mousePosition;
            }

            if (targetObject.tag == "Mirror Wall Collider")
            {
                Debug.Log("This is a collider");
                SoundFXManager.Instance.PlaySoundFXClip(pickUpSound, transform, volume);
                selectedObject = targetObject.transform.parent.gameObject;
            }

            

        }

        if (selectedObject)
        {
            
            selectedObject.transform.position = mousePosition + offset;

            
        }

        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            SoundFXManager.Instance.PlaySoundFXClip(putDownSound, transform, volume);
            selectedObject.transform.position = new Vector3(Mathf.RoundToInt(selectedObject.transform.position.x), Mathf.RoundToInt(selectedObject.transform.position.y), 0f);

            selectedObject = null;
        }

    }
    public void MoveBackToIntital(GameObject thisMirror)
    {
        Debug.Log("MOVE BACK");
        thisMirror.transform.position = new Vector3 (initialPosition.x, initialPosition.y, 0f);
    }


}
