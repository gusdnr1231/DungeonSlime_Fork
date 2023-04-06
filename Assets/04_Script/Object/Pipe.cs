using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;
using DG.Tweening;
using Interface;
using System;

public class Pipe : MonoBehaviour
{

    [SerializeField] private Transform outputPipe;

    public void UsePipe(Transform useObjcet, Action completeAction)
    {

        if(useObjcet.TryGetComponent<IMoveAbleObject>(out var able))
        {

            able.moveAble = false;

        }

        useObjcet.DOMoveY(useObjcet.transform.position.y - 1, 1.5f)
        .OnComplete(() =>
        {

            useObjcet.transform.position = outputPipe.position;

            useObjcet.DOMoveY(useObjcet.transform.position.y + 1, 1.5f)
            .SetDelay(1f)
            .OnComplete(() =>
            {

                able.moveAble = true;
                completeAction();

            });

        });

    }

}
