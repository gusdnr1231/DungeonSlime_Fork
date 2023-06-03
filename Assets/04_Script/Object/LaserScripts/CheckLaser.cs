using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckLaser : MonoBehaviour
{
    public UnityEvent laserCheckEvent;

    [SerializeField]
    private Vector2 dir;
    public Vector2 CheckDir => dir;
}
