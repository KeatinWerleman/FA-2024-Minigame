using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiswitchHandler : MonoBehaviour
{
    public GameObject[] switches;
    public GameObject affectedObject;
    public GameObject objectLocationSprite;
    public bool areAllSwitchesSame;
    public Vector3 tempPosition;
    public Quaternion tempRotation;
    public string multiswitchTag;
    int count = 0;
    
    // Start is called before the first frame update
    public static MultiswitchHandler Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        switches = GameObject.FindGameObjectsWithTag(multiswitchTag);
        

    }


    public void CheckIfAllSwitchesAreHit()
    {
        

        foreach (GameObject gameObject in switches)
        {
            
            if (gameObject.GetComponent<Multiswitch>().isSwitchActive == true)
            {
                count = count + 1;
                Debug.Log("Checked " + count + "switch(es)");


                
                
            }

            else if (gameObject.GetComponent<Multiswitch>().isSwitchActive == false)
            {
                Debug.Log("stopped checking after " + count + " switch(es)");
                areAllSwitchesSame = false;
                count = 0;

                break;
            }
            if (count == switches.Length)
            {
                areAllSwitchesSame = true;
            }
            if (areAllSwitchesSame)
            {
                ActivateSwitchEvent();
            }

        }

    }

    public void ActivateSwitchEvent()
    {
        
        tempPosition = affectedObject.transform.position;
        tempRotation = affectedObject.transform.rotation;
        affectedObject.transform.position = objectLocationSprite.transform.position;
        affectedObject.transform.rotation = objectLocationSprite.transform.rotation;
        objectLocationSprite.transform.position = tempPosition;
        objectLocationSprite.transform.rotation = tempRotation;
    }
}
