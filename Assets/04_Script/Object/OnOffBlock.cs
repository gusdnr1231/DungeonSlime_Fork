using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class OnOffBlock : MonoBehaviour
{

    [SerializeField] private UnityEvent<bool> changeEvent;

    private bool isOn;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        


    }

    private void ChangeOnOff()
    {


    }

}
