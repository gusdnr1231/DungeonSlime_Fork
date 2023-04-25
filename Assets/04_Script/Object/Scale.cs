using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class Scale : MonoBehaviour
{
    [SerializeField] private GameObject scale1;
    [SerializeField] private GameObject scale2;
    [SerializeField] private GameObject stick;
    [SerializeField] private Vector2 overlapBoxSize;

    const float stonOrgPosY = -1.8f;

    private void Update() => SetScale();

    public void SetScale()
    {
        SetStick(Angle());
        SetBalanceStones(Angle());
    }

    void SetStick(float angle)
    {
        scale1.transform.DOMoveY(stonOrgPosY - (angle / 4), 2f);
        scale2.transform.DOMoveY(stonOrgPosY + (angle / 4), 2f);
    }

    void SetBalanceStones(float angle)
    {
        float eulerZ = Mathf.Lerp(stick.transform.rotation.z, angle, Time.deltaTime);
        stick.transform.DORotate(new Vector3(0, 0, angle * 4.5f), 2f);
    }

    float Angle()
    {
        return HeavySenser(scale1) - HeavySenser(scale2);
    }

    float HeavySenser(GameObject scale)
    {
        float sumHeavy = 0;
        try
        {
            RaycastHit2D[] d = Physics2D.BoxCastAll(scale.transform.position + new Vector3(0, 1.05f, 0),
            overlapBoxSize, 0, Vector2.zero);

            for (int i = 0; i < d.Length; i++)
            {
                Debug.Log(d[i].transform.name);
                sumHeavy += d[i].transform.GetComponent<Heavy>().heavy;
                
            }

            return sumHeavy;
        }
        catch (Exception exp)
        {
            Debug.Log("exp");
            return sumHeavy;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(scale1.transform.position + new Vector3(0, 1.05f, 0), overlapBoxSize);
    }
}
