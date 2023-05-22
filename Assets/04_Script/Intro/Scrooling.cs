using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Scrooling : MonoBehaviour
{
    [SerializeField] private float downSpeed;
    [SerializeField] private float maxDownY;
    [SerializeField] private float backY;

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        Vector2 pos = transform.position;
        if (pos.y <= maxDownY)
            pos = new Vector2(0, backY);
        pos.y -= downSpeed * Time.deltaTime;
        transform.position = pos;
    }

    void StopScroll()
        => downSpeed = 0;
}
