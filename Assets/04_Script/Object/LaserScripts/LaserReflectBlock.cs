using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReflectBlock : LaserBlock
{
    //currenLaser에서 입력 받고 반사하는 위치는 따로 만들기
    [SerializeField]
    private GameObject secondLaser;

    ShotLaser firstShotLaser;
    ShotLaser secondShotLaser;

    protected override void Awake()
    {
        base.Awake();

        LaserSetting(currentLaser, secondLaser);
    }

    public void SetReflectLeft()
    {
        SetReflect(leftLaser);
    }
    public void SetReflectRight()
    {
        SetReflect(rightLaser);
    }
    public void SetReflectTop()
    {
        SetReflect(topLaser);
    }
    public void SetReflectBottom()
    {
        SetReflect(bottomLaser);
    }
    private void SetReflect(GameObject reflectObj)
    {
        ResetSetting();
        currentLaser.SetActive(true);
        reflectObj.SetActive(true);
        secondLaser = reflectObj;
    }

    private void LaserSetting(GameObject first, GameObject second)
    {
        firstShotLaser = first.GetComponent<ShotLaser>();
        secondShotLaser = second.GetComponent<ShotLaser>();

        first.GetComponent<CheckLaser>().laserCheckEvent.AddListener(() =>
        {
            secondShotLaser.Shot(lineRenderer);
        });
        second.GetComponent<CheckLaser>().laserCheckEvent.AddListener(() =>
        {
            firstShotLaser.Shot(lineRenderer);
        });

    }
}
