using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class OnOffBlock : MonoBehaviour
{

    [SerializeField] private UnityEvent<bool> changeEvent;

    private bool isOn = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        ChangeOnOff();

    }

    private void ChangeOnOff()
    {

        isOn = !isOn;
        changeEvent?.Invoke(isOn);

    }

}
