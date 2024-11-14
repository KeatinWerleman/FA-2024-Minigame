using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWinPanel : MonoBehaviour
{
    
    public string levelSelectSceneName;
    
    

    public void OpenNextLevel(int nextLevelNumber)
    {

        SceneManager.LoadScene("Level " + nextLevelNumber);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(levelSelectSceneName);

    }
}
