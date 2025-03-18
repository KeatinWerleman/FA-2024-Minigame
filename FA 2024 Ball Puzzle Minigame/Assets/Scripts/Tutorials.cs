using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorials : MonoBehaviour
{
    private GameObject mouse;
    
    private GameObject levelUI;
    // Start is called before the first frame update
    void Start()
    {
        mouse = GameObject.Find("Mouse");
        levelUI = GameObject.Find("Level UI Panel");
    }

    public void OpenTutorialPanel(GameObject tutorialPanel)
    {
        mouse.SetActive(false);
        levelUI.SetActive(false);
        tutorialPanel.SetActive(true);

    }

    public void CloseTutorialPanel(GameObject tutorialPanel)
    {
        mouse.SetActive(true);
        levelUI.SetActive(true);
        tutorialPanel.SetActive(false);
    }
}
