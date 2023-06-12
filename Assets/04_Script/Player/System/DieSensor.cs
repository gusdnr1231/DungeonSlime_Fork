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

    public string dieTag { get; set; }
    public bool dieAble { get; set; } = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!dieAble) return;

        foreach(var tag in tags) 
        {
            if (collision.CompareTag(tag))
            {

                if (isDie && useIsDie) return;

                dieTag = tag;
                isDie = true;
                dieEvent?.Invoke();

            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!dieAble) return;

        foreach (var tag in tags)
        {

            if (collision.transform.CompareTag(tag))
            {

                if (isDie && useIsDie) return;

                dieTag = tag;
                isDie = true;
                Debug.Log(collision.transform.name);
                dieEvent?.Invoke();

            }

        }

    }

    public void InvokeDieEvent()
    {

        if (isDie && useIsDie) return;

        dieTag = tag;
        isDie = true;
        dieEvent?.Invoke();

    }

}
