using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
     public static BackgroundMusicManager instance;
    public AudioSource AudioSource;
    public float volume;

    private void Awake()
    {

        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }


            
    }

    private void Update()
    {

        volume = PlayerPrefs.GetFloat("Background Music Volume");
        Debug.Log("Background Music volume = " + volume);
        AudioSource.volume = volume;
    }
}
