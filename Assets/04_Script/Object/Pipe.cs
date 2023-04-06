using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;
using DG.Tweening;
using Interface;

public class Pipe : MonoBehaviour
{

    [SerializeField] private Transform outputPipe;

    public void UsePipe(Transform useObjcet)
    {

        if(useObjcet.TryGetComponent<IMoveAbleObject>(out var able))
        {

            able.moveAble = false;

        }

        useObjcet.DOMoveY(useObjcet.transform.position.y - 1, 0.3f)
        .OnComplete(() =>
        {

            useObjcet.transform.position = outputPipe.position;

            useObjcet.DOMoveY(useObjcet.transform.position.y + 1, 0.3f)
            .OnComplete(() =>
            {

                able.moveAble = true;

            });

        });

    }

}
