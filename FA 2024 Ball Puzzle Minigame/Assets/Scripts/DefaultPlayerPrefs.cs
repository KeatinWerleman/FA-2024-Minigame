using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPlayerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Sound Effects Volume", 0.2f);
        PlayerPrefs.SetFloat("Background Music Volume", 1f);
        PlayerPrefs.SetString("Are Grids On", "true");
        PlayerPrefs.SetString("Are Particles On", "true");
    }

    // Update is called once per frame

    public void QuitGame()
    {
        Application.Quit();
    }
    
        
    
}
