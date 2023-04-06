using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;
using DG.Tweening;

public class Pipe : EnemyRoot
{
    [SerializeField] private Transform otherPipe;
    private GameObject playerTrs;

    EnemyMovementHide movementHide;

    protected override void Awake()
    {

        base.Awake();
        movementHide = gameObject.GetComponent<EnemyMovementHide>();
        playerTrs = GameObject.FindWithTag("Player");
    }

    void Spon()
    {
        Debug.Log(383);
        movementHide.SetValMoveAble();

        playerTrs.GetComponent<SpriteRenderer>().enabled = true;

        float up = playerTrs.transform.position.y - transform.position.y;

        playerTrs.transform.DOMoveY(transform.position.y, 1);
        playerTrs.transform.position = otherPipe.position;
        playerTrs.transform.DOMoveY(otherPipe.position.y + up, 1);

        input.BounceExecute();
    }

    public override void AddEvent()
    {

        input.OnHideEvnet += Spon;

    }

    public override void RemoveEvent()
    {

        input.OnHideEvnet -= Spon;

    }
}
