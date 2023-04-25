using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DieSensor : MonoBehaviour
{

    [SerializeField] private List<string> tags = new List<string>();
    [SerializeField] private UnityEvent dieEvent;
    [SerializeField] private bool useIsDie = true;

    private bool isDie;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        foreach(var tag in tags) 
        {

            if (collision.CompareTag(tag))
            {

                if (isDie && useIsDie) return;

                isDie = true;
                dieEvent?.Invoke();

            }

        }

    }

}
