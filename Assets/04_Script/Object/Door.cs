using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{

    [SerializeField] private UnityEvent clearEvent;
    [SerializeField] private List<string> clearAbleTag;

    private JumpUISetting jumpUISetting;

    private void Awake()
    {
        
        jumpUISetting = FindObjectOfType<JumpUISetting>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        foreach(string tag in clearAbleTag)
        {

            if (collision.CompareTag(tag))
            {

                jumpUISetting.SetClear();

            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        foreach (string tag in clearAbleTag)
        {

            if (collision.CompareTag(tag))
            {

                jumpUISetting.SetOrigin();

            }

        }

    }

}
