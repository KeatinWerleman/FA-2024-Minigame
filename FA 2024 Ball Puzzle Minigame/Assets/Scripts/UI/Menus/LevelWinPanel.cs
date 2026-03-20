using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWinPanel : MonoBehaviour
{
    
    public string levelSelectSceneName;
    public string winScreenSceneName;
    
    public void OpenNextLevel(int nextLevelNumber)
    {




        Debug.Log("Trying to load: Level " + nextLevelNumber);
        
        SceneManager.LoadScene("Test Level " + nextLevelNumber);
        Debug.Log("Loaded Level " + nextLevelNumber);






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
