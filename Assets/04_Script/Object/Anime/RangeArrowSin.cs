using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeArrowSin : MonoBehaviour
{
    [SerializeField] float timeSpeed = 3;
    [SerializeField] float range = 2;

    void Update()
    {
        transform.position -= new Vector3(0, (Mathf.Sin(Time.time * timeSpeed) / 1000f) / range, 0);
    }
}
