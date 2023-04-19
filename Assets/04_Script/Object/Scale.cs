using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField] private GameObject scale1;
    [SerializeField] private GameObject scale2;
    [SerializeField] private GameObject stick;
    [SerializeField] private Vector2 overlapBoxSize;

    private Transform s1T, s2T;

    private void Awake()
    {
        s1T = scale1.transform;
        s2T = scale2.transform;
    }

    void Update()
    {
        scale1.transform.position = s1T.position;
        scale2.transform.position = s2T.position;
    }

    public void SetScale()
    {
        SetStick(Angle());
        SetBalanceStones(Angle());
    }

    void SetStick(float angle)
    {
        float position1Y = Mathf.Lerp(s1T.position.y, s1T.position.y + angle, Time.deltaTime);
        float position2Y = Mathf.Lerp(s2T.position.y, s2T.position.y + angle, Time.deltaTime);

        s1T.position = new Vector3(s1T.position.x, position1Y);
        s2T.position = new Vector3(s2T.position.x, position2Y);
    }

    void SetBalanceStones(float angle)
    {
        float eulerZ = Mathf.Lerp(stick.transform.rotation.z, angle, Time.deltaTime);
        stick.transform.rotation = Quaternion.Euler(0, 0, eulerZ);
    }

    float Angle()
    {
        return HeavySenser(scale1) - HeavySenser(scale2);
    }

    float HeavySenser(GameObject scale)
    {
        try
        {
            RaycastHit2D[] d = Physics2D.BoxCastAll(scale.transform.position + new Vector3(0, 1, 0),
            new Vector2(2.9f, 0.2f), 0, Vector2.zero);

            float sumHeavy = 0;
            for (int i = 0; i < d.Length; i++)
            {
                sumHeavy += d[i].transform.GetComponent<Heavy>().heavy;
                Debug.Log(sumHeavy);
            }

            Debug.Log("aa");
            return sumHeavy;
        }
        catch (Exception exp)
        {
            return 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(scale1.transform.position + new Vector3(0, 1, 0), overlapBoxSize);
    }
}
