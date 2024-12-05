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
        
        SceneManager.LoadScene("Level " + nextLevelNumber);

        
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
