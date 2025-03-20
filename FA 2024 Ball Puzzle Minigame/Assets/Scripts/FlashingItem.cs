using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlashingItem : MonoBehaviour
{

    
    public Color buttonColor;
    public Image buttonImage;
    public float maxChangeValue;
    public float changeValue = 1;
    public float currentRedValue;
    public float minChangeValue;
    public bool isIncreasing;
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonColor = GetComponent<Image>().color;
        currentRedValue = buttonColor.r;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isIncreasing == true)
        {
            IncreaseAlphaValue();
        }

        else if (isIncreasing == false)
        {
            DecreaseAlphaValue();
        }
    }


    public void IncreaseAlphaValue()
    {
        buttonColor.r += 1;
        currentRedValue = buttonColor.r;
        buttonImage.color = buttonColor;
        if (buttonColor.r >= maxChangeValue)
        {
            isIncreasing = false;
            buttonColor.r = minChangeValue - 1;
            buttonImage.color = buttonColor;
        }
    }
    
    public void DecreaseAlphaValue()
    {
        buttonColor.r -= 1;
        currentRedValue = buttonColor.r;
        buttonImage.color = buttonColor;
        if (buttonColor.r <= minChangeValue)
        {
            isIncreasing = true;
            buttonColor.r = minChangeValue + 1;
            buttonImage.color = buttonColor;

        }
    }
}
