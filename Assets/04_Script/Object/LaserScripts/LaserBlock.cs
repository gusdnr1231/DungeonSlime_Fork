using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserBlock : MonoBehaviour
{
    [SerializeField] protected GameObject topLaser;
    [SerializeField] protected GameObject bottomLaser;
    [SerializeField] protected GameObject leftLaser;
    [SerializeField] protected GameObject rightLaser;

    [SerializeField]
    protected GameObject currentLaser = null;
    protected LineRenderer lineRenderer = null;

    protected virtual void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetLeft()
    {
        ResetSetting();
        LaserSetting(leftLaser);
    }
    public void SetRight()
    {
        ResetSetting();
        LaserSetting(rightLaser);
    }
    public void SetTop()
    {
        ResetSetting();
        LaserSetting(topLaser);
    }
    public void SetBottom()
    {
        ResetSetting();
        LaserSetting(bottomLaser);
    }
    protected void LaserSetting(GameObject laser)
    {
        laser.gameObject.SetActive(true);
        currentLaser = laser;
    }
    protected void ResetSetting()
    {
        topLaser.gameObject.SetActive(false);
        bottomLaser.gameObject.SetActive(false);
        leftLaser.gameObject.SetActive(false);
        rightLaser.gameObject.SetActive(false);
    }
}
