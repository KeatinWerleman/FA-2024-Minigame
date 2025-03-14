using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWinPanel : MonoBehaviour
{
    
    public string levelSelectSceneName;
    public string winScreenSceneName;
    public bool isTestBuild;
    public void OpenNextLevel(int nextLevelNumber)
    {

        if (!isTestBuild)
        {
            SceneManager.LoadScene("Level " + nextLevelNumber);
        }

        else if (isTestBuild) 
        {
            SceneManager.LoadScene("Test Level " + nextLevelNumber);
        }
        
        

        
    }

    public void ResetCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
    public void OpenMainMenu()
    {
        SceneManager.LoadScene(levelSelectSceneName);

    }

    public void OpenWinScreen()
    {
        SceneManager.LoadScene(winScreenSceneName);
    }
}
