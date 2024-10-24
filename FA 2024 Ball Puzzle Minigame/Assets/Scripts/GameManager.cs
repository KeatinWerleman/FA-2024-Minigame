using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mouseObject;
    public static GameManager Instance;
    public bool canWeMoveMirrors = true;
    public bool isLevelWon = false;
    public GameObject levelWinPanel;
    

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
            BallLauncher.Instance.ClearField();
            mouseObject.SetActive(true);
            canWeMoveMirrors = true;
            
        }

    }




    public void HandleWin()
    {
       
        Debug.Log("LEVEL WON");
        isLevelWon = true;
        levelWinPanel.SetActive(true);
        UnlockNewLevel();
        //celebrate win, bring up menu with button for next level
        
    }

    void UnlockNewLevel()
    {
        PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
        PlayerPrefs.Save();
    }


}
