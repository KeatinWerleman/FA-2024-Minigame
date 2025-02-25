using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject levelUI;
    [SerializeField] private GameObject Mouse;

    private void Start()
    {
        Mouse = GameObject.FindGameObjectWithTag("Mouse");
        levelUI = GameObject.FindGameObjectWithTag("Level UI");
        
    }
    public void Pause()
    {
        
        pauseMenu.SetActive(true);
        Mouse.SetActive(false);
        levelUI.SetActive(false);
        Time.timeScale = 0f;
        

    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Mouse.SetActive(true);
        levelUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StopLaunching()
    {
        GameManager.Instance.TurnLaunchStateOn();
    }
}
