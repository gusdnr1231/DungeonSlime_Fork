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

            var rigid = useObjcet.GetComponent<Rigidbody2D>();
            var col = useObjcet.GetComponent<BoxCollider2D>();

            col.enabled = false;
            rigid.gravityScale = 0;
            rigid.velocity = Vector3.zero;

            useObjcet.DOMoveY(useObjcet.transform.position.y - 1, 1.5f)
            .OnComplete(() =>
            {
            
                Vector3 pos = outputPipe.position;
                pos.y -= 1f;
            
                useObjcet.transform.position = pos;
            
                useObjcet.DOMoveY(useObjcet.transform.position.y + 1, 1.5f)
                .SetDelay(1f)
                .OnComplete(() =>
                {
            
                    able.moveAble = true;
                    col.enabled = true;
                    completeAction();
                    rigid.gravityScale = 1;
                    rigid.velocity = Vector3.zero;

                });
            
            });

        }



    }

}
