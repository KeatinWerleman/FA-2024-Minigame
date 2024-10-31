using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelWinPanel : MonoBehaviour
{
    public int nextSceneLoad;
    public string levelSelectSceneName;
    public void OpenNextLevel()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        if(SceneManager.GetActiveScene().buildIndex == 8)
        {
            Debug.Log("You Completed ALL Levels");
                
            //Show Win Screen or Somethin.
        }
        else
        {
            //Move to next level
            SceneManager.LoadScene(nextSceneLoad);

            //Setting Int for Index
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(levelSelectSceneName);
    }
}
