using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWinPanel : MonoBehaviour
{
    public string levelSelectSceneName;
    public void OpenNextLevel(int levelID)
    {
        string nextLevelName = "Level " + levelID;
        SceneManager.LoadScene(nextLevelName);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(levelSelectSceneName);
    }
}
