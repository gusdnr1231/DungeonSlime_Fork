using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDecoAnimation : MonoBehaviour
{
    private Vector3 startPos;

    [SerializeField]
    private Vector3 moveDir;

    private void Awake()
    {
        startPos = transform.position;
    }


}
