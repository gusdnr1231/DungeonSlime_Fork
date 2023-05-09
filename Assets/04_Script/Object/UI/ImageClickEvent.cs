using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ImageClickEvent : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private UnityEvent clickEvent;

    public void OnPointerDown(PointerEventData eventData)
    {

        clickEvent?.Invoke();

    }

}
