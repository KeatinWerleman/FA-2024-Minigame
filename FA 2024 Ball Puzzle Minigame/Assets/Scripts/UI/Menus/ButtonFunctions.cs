using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using DG.Tweening;
public class ButtonFunctions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    private Tweener tween;
    [Header("UI Scale Change Values")]

    [SerializeField] Vector3 highlighedScale = new Vector3(1.1f, 1.1f, 1.1f);
    [SerializeField] Vector3 nonHighlightedScale = Vector3.one;
    [SerializeField] float scaleChangeTime = 0.25f;
    //Use this to check what Events are happening
    BaseEventData m_BaseEvent;

    private void Awake()
    {
        //tween = GetComponent<Tweener>();
        tween.SetUpdate(true);
    }
    public void OnPointerEnter(PointerEventData eventData)// triggers when mouse hovers over button
    {
        Debug.Log("Pointer entered button");
        this.gameObject.transform.DOScale(highlighedScale, scaleChangeTime).SetUpdate(true);
        Debug.Log("Button made larger");
    }
    public void OnPointerExit(PointerEventData eventData) // triggers when mouse stops hovering over button
    {
        Debug.Log("Pointer left button");
        this.gameObject.transform.DOScale(nonHighlightedScale, scaleChangeTime).SetUpdate(true);
        Debug.Log("Button made smaller");

    }


    public void OnSelect(BaseEventData eventData) // triggers when button is selected
    {
        this.gameObject.transform.DOScale(highlighedScale, scaleChangeTime);
    }



}

