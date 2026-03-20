using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class OptionsManager : MonoBehaviour
{
    public float soundEffectsVolume;
    public float backgroundMusicVolume;
    public bool areGridsOn;
    public bool areParticlesOn;
    public Button particleEffectsButton;
    public Button gridsButton;
    public Slider soundEffectsVolumeSlider;
    public Slider backgroundMusicVolumeSlider;
    public TextMeshProUGUI soundEffectsVolumeText;
    public TextMeshProUGUI backgroundMusicVolumeText;
    public TextMeshProUGUI gridsButtonText;
    public TextMeshProUGUI particlesButtonText;
    public Color onColor;
    public Color offColor;
    // Start is called before the first frame update
    void Start()
    {
        
        
        
        ApplySettings();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ChangeSFXVolume()
    {
        soundEffectsVolume = soundEffectsVolumeSlider.value;
        soundEffectsVolumeText.SetText("Sound Effects Volume: " + soundEffectsVolume);
        PlayerPrefs.SetFloat("Sound Effects Volume", soundEffectsVolume/100);
    }

    public void ChangeBGMusicVolume()
    {
        backgroundMusicVolume = backgroundMusicVolumeSlider.value;
        backgroundMusicVolumeText.SetText("BG Music Volume: " +  backgroundMusicVolume);
        PlayerPrefs.SetFloat("Background Music Volume", backgroundMusicVolume/100);

    }

    public void ChangeGridSettings()
    {
        Image gridsButtonImage = gridsButton.GetComponent<Image>();
        if (areGridsOn)
        {

            areGridsOn = false;
            PlayerPrefs.SetString("Are Grids On", "false");
            gridsButtonImage.color = new Color(offColor.r, offColor.g, offColor.b);
            gridsButtonText.SetText("OFF");
            
        }

        else if (!areGridsOn)
        {
            areGridsOn= true;
            PlayerPrefs.SetString("Are Grids On", "true");
            gridsButtonImage.color = new Color(onColor.r, onColor.g, onColor.b);
            gridsButtonText.SetText("ON");
        }
    }

    public void ChangeParticleSettings()
    {
        Image particleEffectsButtonImage = particleEffectsButton.GetComponent<Image>();

        if (areParticlesOn)
        {
            areParticlesOn = false;
            PlayerPrefs.SetString("Are Particles On", "false");

            particleEffectsButtonImage.color = new Color(offColor.r, offColor.g, offColor.b);


            particlesButtonText.SetText("OFF");

        }

        else if (!areParticlesOn)
        {
            areParticlesOn = true;
            PlayerPrefs.SetString("Are Particles On", "true");
            particleEffectsButtonImage.color = new Color (onColor.r, onColor.g, onColor.b);
            particlesButtonText.SetText("ON");
        }
    }

    public void ApplySettings()
    {
        Image particleEffectsButtonImage = particleEffectsButton.GetComponent<Image>();
        Image gridsButtonImage = gridsButton.GetComponent<Image>();
        if (PlayerPrefs.GetString("Are Particles On") == "true")
        {
            areParticlesOn = true;
            particleEffectsButtonImage.color = new Color(onColor.r, onColor.g, onColor.b);
            particlesButtonText.SetText("ON");
        }

        else if (PlayerPrefs.GetString("Are Particles On") == "false")
        {
            areParticlesOn = false;
            particleEffectsButtonImage.color = new Color(offColor.r, offColor.g, offColor.b);
            particlesButtonText.SetText("OFF");
        }

        if (PlayerPrefs.GetString("Are Grids On") == "true")
        {
            areGridsOn = true;
            gridsButtonImage.color = new Color(onColor.r, onColor.g, onColor.b);
            gridsButtonText.SetText("ON");
        }

        else if (PlayerPrefs.GetString("Are Grids On") == "false")
        {
            areGridsOn = false;
            gridsButtonImage.color = new Color(offColor.r, offColor.g, offColor.b);
            gridsButtonText.SetText("OFF");
        }

    }
    }


