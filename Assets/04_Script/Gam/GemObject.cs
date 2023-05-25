using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemObject : MonoBehaviour
{

    [SerializeField] private string[] getAbleObjectTag;
    [SerializeField] private string getKey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        foreach(var item in getAbleObjectTag)
        {

            if (collision.CompareTag(item))
            {

                PlayerPrefs.SetInt(getKey, int.MaxValue);
                Destroy(gameObject);

            }

        }

    }

}
