using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : MonoBehaviour
{
    public float heavy;
    public bool isGround;
    public float time;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Scale")
        {
            isGround = true;
            Debug.Log("in");
            DOTween.KillAll();
            collision.transform.parent.GetComponent<Scale>().SetScale();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        time += Time.deltaTime;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Scale" && time > 0.3f)
        {
            time = 0;
            isGround = false;
            Debug.Log("exit");
            DOTween.KillAll();
            collision.transform.parent.GetComponent<Scale>().SetScale();
        }
    }
}
