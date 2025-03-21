using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
public class FlashingItem : MonoBehaviour
{
    public Color buttonColor;
    public Image buttonImage;
    public float currentRedValue;
    public float currentGreenValue;
    public float currentBlueValue;
    public float startingRedValue;
    public float startingGreenValue;
    public float startingBlueValue;
    static float changeValue = 0f;
    public bool isRedChanging;
    public bool isGreenChanging;
    public bool isBlueChanging;
    private float maximum = 1f;
    private float minimum;
    public bool isIncreasing;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonColor = GetComponent<Image>().color;
        currentRedValue = buttonColor.r;
        currentGreenValue = buttonColor.g;
        currentBlueValue = buttonColor.b;
        startingRedValue = buttonColor.r;
        startingGreenValue = buttonColor.g;
        startingBlueValue = buttonColor.b;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRedChanging && !isGreenChanging && !isBlueChanging)
        {
            currentRedValue = Mathf.Lerp(minimum, maximum, changeValue);
            changeValue += 0.5f * Time.deltaTime;
            if (changeValue > 1.0f)
            {
                float temp = maximum;
                maximum = minimum;
                minimum = temp;
                changeValue = 0.0f;
            }
            buttonColor.r = currentRedValue;
            buttonColor.g = currentGreenValue;
            buttonColor.b = currentBlueValue;
            buttonImage.color = new Color (buttonColor.r, buttonColor.g, buttonColor.b);
           
            

        }

        else if (!isRedChanging && isGreenChanging && !isBlueChanging)
        {
            currentGreenValue = Mathf.Lerp(minimum, maximum, changeValue);
            changeValue += 0.5f * Time.deltaTime;
            if (changeValue > 1.0f)
            {
                float temp = maximum;
                maximum = minimum;
                minimum = temp;
                changeValue = 0.0f;
            }
            buttonColor.r = currentRedValue;
            buttonColor.g = currentGreenValue;
            buttonColor.b = currentBlueValue;
            buttonImage.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b);
        }

        else if (!isRedChanging && !isGreenChanging && isBlueChanging)
        {
            currentBlueValue = Mathf.Lerp(minimum, maximum, changeValue);
            changeValue += 2f * Time.deltaTime;
            if (changeValue > 1.0f)
            {
                float temp = maximum;
                maximum = minimum;
                minimum = temp;
                changeValue = 0.0f;
            }
            buttonColor.r = currentRedValue;
            buttonColor.g = currentGreenValue;
            buttonColor.b = currentBlueValue;
            buttonImage.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b);
        }

    }

    public void TurnOffFlashing()
    {
        isRedChanging = false;
        isGreenChanging = false;
        isBlueChanging = false;
        buttonImage.color = new Color(startingRedValue, startingGreenValue, startingBlueValue); 
    }

}
