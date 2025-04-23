using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] worldPanels;
    public bool isForTestBuild;
    public bool buildHasLockedLevels;
    private void Start()
    {

        

     
        if (buildHasLockedLevels)
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

    public void OpenWorldPanel(int worldNumber)
    {
        for (int i = 0; i < worldPanels.Length; i++)
        {
            worldPanels[i].gameObject.SetActive(false);
            worldPanels[worldNumber - 1].gameObject.SetActive(true);
        }
    }

    public void CloseWorldPanel()
    {
        for (int i = 0; i < worldPanels.Length; i++)
        {
            worldPanels[i].gameObject.SetActive(false);
        }
    }

   
    public void Clear()
    {

        if (buildHasLockedLevels)
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
    
}
