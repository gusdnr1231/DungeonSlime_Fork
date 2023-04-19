using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : MonoBehaviour
{
    public float heavy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Scale")
        {
            collision.transform.parent.GetComponent<Scale>().SetScale();
        }
    }
}
