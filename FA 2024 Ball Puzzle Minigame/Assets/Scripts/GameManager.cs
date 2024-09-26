using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mouseObject;
    public static GameManager Instance;
    public bool canWeMoveMirrors = true;
    public bool isLevelWon = false;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            TurnLaunchStateOn();
        
        }
    }

    public void TurnLaunchStateOff()
    {
        if (canWeMoveMirrors)
        {
            mouseObject.SetActive(false);
            canWeMoveMirrors = false;
        }
    }

    public void TurnLaunchStateOn()
    {
        if (canWeMoveMirrors == false)
        {
            mouseObject.SetActive(true);
            canWeMoveMirrors = true;
        }

    }




    public void HandleWin()
    {
       
        Debug.Log("LEVEL WON");
        isLevelWon = true; 
        //celebrate win, bring up menu with button for next level
        
    }


}
