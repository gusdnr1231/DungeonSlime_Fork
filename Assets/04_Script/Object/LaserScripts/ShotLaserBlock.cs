using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLaserBlock : LaserBlock
{
    private readonly float shotDelay = 2.5f;
    private ShotLaser shotLaser;

    protected override void Awake()
    {
        base.Awake();
        shotLaser = currentLaser.GetComponent<ShotLaser>();

        StartCoroutine(LaserShotLoop());
    }
    IEnumerator LaserShotLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(shotDelay);
            shotLaser.Shot(lineRenderer);
        }
    }
}
