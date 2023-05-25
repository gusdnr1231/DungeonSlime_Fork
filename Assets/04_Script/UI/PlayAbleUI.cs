using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayAbleUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool isUpdate = false;

    [SerializeField] private float returnValue;
    [SerializeField] private UnityEvent<float> clickEvent;
    [SerializeField] private UnityEvent<float> clickUpEvent;
    [SerializeField] private UnityEvent<float> clickAlwayEvent;

    public void OnPointerDown(PointerEventData eventData)
    {

        isUpdate = true;
        clickEvent?.Invoke(returnValue);

    }

    public void OnPointerUp(PointerEventData eventData)
    {

        isUpdate = false;
        clickUpEvent?.Invoke(0);

    }

    private void Update()
    {
        
        if(isUpdate) 
        {

            clickAlwayEvent?.Invoke(returnValue);


        }

    }

}
