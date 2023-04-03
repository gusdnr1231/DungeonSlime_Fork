using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSensor : MonoBehaviour
{

    [SerializeField] private List<string> tags = new List<string>();

    private void OnTriggerEnter2D(Collider2D collision)
    {

        foreach(var tag in tags) 
        {

            if (collision.CompareTag(tag))
            {

                Debug.Log(1);

            }

        }

    }

}
