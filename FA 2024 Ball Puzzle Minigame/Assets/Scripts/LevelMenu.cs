using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public bool isForTestBuild;

    private void Start()
    {

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        
        
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void OpenLevel(int levelId)
    {
        if (isForTestBuild)
        {
            string levelName = "Test Level " + levelId;
            SceneManager.LoadScene(levelName);
        }

        else if (!isForTestBuild)
        {
            string levelName = "Level " + levelId;
            SceneManager.LoadScene(levelName);
        }
        
    }
   
    public void Clear()
    {
        PlayerPrefs.DeleteAll();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
    
}
