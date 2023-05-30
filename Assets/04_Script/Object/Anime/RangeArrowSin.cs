using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeArrowSin : MonoBehaviour
{
    void Update()
    {
        transform.position -= new Vector3(0, (Mathf.Sin(Time.time * 3) / 1000f) / 2, 0);
    }
}
