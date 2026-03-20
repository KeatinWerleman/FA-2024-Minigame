using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mouseObject;
    public static GameManager Instance;
    public int levelPoints;
    public int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public bool canWeMoveMirrors = true;
    public bool isLevelWon = false;
    public GameObject levelWinPanel;
    public string thisLevel;
    
    

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
        Time.timeScale = 1f;
        highScore = PlayerPrefs.GetInt(thisLevel, 0);
        if (highScore > 0 )
        {
            highScoreText.SetText("Best Score:" + highScore.ToString());
        }

        else
        {
            highScoreText.SetText("Best Score: ");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            ResetLevel();
        
        }

        if (Input.GetMouseButtonDown(1))
        {
            TurnLaunchStateOn();
        }

        
    }

    public void UpdateScore (int valueToAdd)
    {
        levelPoints += valueToAdd;
        scoreText.SetText("Score: " + levelPoints.ToString());


    }

    public void StartLevel()
    {
        
        mouseObject.SetActive(true);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        PlayerPrefs.SetInt(thisLevel, levelPoints);
        //celebrate win, bring up menu with button for next level
        
    }

    void UnlockNewLevel()
    {
        Debug.Log("UNLOCKING LEVEL");
        int reachedIndex = PlayerPrefs.GetInt("ReachedIndex");
        Debug.Log("Reached Index is:" + reachedIndex);
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            Debug.Log("LEVEL START UNLOCK");
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel") + 1);
            PlayerPrefs.Save();
            Debug.Log("LEVEL FINISHED UNLOCK");
        }
    }




}
