using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserCheckBlock : LaserBlock
{
    public UnityEvent OnLaserEvent;
    private CheckLaser checkLaser;

    protected override void Awake()
    {
        base.Awake();
        checkLaser = currentLaser.GetComponent<CheckLaser>();
        checkLaser.laserCheckEvent.AddListener(LaserCheck);
    }

    public void LaserCheck()
    {
        OnLaserEvent?.Invoke();
    }
}
