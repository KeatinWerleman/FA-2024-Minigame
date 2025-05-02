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
    public bool isMovingUp;
    private float startingRedValue;
    private float startingGreenValue;
    private float startingBlueValue;
    
    [SerializeField] float changeValue = 0f;
    [SerializeField] float flashingSpeed;
    public bool isRedChanging;
    public bool isGreenChanging;
    public bool isBlueChanging;
   
    
    
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
            
            if (!isMovingUp)
            {
                currentRedValue = Mathf.SmoothDamp(currentRedValue, 0, ref changeValue, 1f);
            }

            else if (isMovingUp)
            {
                currentRedValue = Mathf.SmoothDamp(currentRedValue, 1, ref changeValue, 1f);
            }

            if (currentRedValue >= .8f)
            {
                isMovingUp = false;
            }

            else if (currentRedValue <= .2f)
            { 
                isMovingUp = true;
            }
            buttonColor.r = currentRedValue;
            buttonColor.g = currentGreenValue;
            buttonColor.b = currentBlueValue;
            buttonImage.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b);
        }

        else if (!isRedChanging && isGreenChanging && !isBlueChanging)
        {
            if (!isMovingUp)
            {
                currentGreenValue = Mathf.SmoothDamp(currentGreenValue, 0, ref changeValue, 1f);
            }

            else if (isMovingUp)
            {
                currentGreenValue = Mathf.SmoothDamp(currentGreenValue, 1, ref changeValue, 1f);
            }

            if (currentGreenValue >= .8f)
            {
                isMovingUp = false;
            }

            else if (currentGreenValue <= .2f)
            {
                isMovingUp = true;
            }
            buttonColor.r = currentRedValue;
            buttonColor.g = currentGreenValue;
            buttonColor.b = currentBlueValue;
            buttonImage.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b);
        }

        else if (!isRedChanging && !isGreenChanging && isBlueChanging)
        {
            if (!isMovingUp)
            {
                currentBlueValue = Mathf.SmoothDamp(currentBlueValue, 0, ref changeValue, 1f);
            }

            else if (isMovingUp)
            {
                currentBlueValue = Mathf.SmoothDamp(currentBlueValue, 1, ref changeValue, 1f);
            }

            if (currentBlueValue >= .8f)
            {
                isMovingUp = false;
            }

            else if (currentBlueValue <= .2f)
            {
                isMovingUp = true;
            }
            buttonColor.r = currentRedValue;
            buttonColor.g = currentGreenValue;
            buttonColor.b = currentBlueValue;
            buttonImage.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b);
        }
    }

    private void ApplyNewColor(float newColorValue)
    {
        buttonColor.r = currentRedValue;
        buttonColor.g = currentGreenValue;
        buttonColor.b = currentBlueValue;
        buttonImage.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b);
    }

    public void TurnOffFlashing()
    {
        isRedChanging = false;
        isGreenChanging = false;
        isBlueChanging = false;
        buttonImage.color = new Color(startingRedValue, startingGreenValue, startingBlueValue); 
    }

}
