using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelMenuForTesting : MonoBehaviour
{
    
    public void OpenLevelByName(string levelName)
    {
        SceneManager.LoadScene(levelName);

    }
}
