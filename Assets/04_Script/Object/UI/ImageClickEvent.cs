using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ImageClickEvent : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private int lockChapter;
    [SerializeField] private UnityEvent clickEvent;

    public void OnPointerDown(PointerEventData eventData)
    {

        if (PlayerPrefs.GetInt("UnlockChapter") >= lockChapter)
            clickEvent?.Invoke();

    }

}
