using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.AI.FSM;
using DG.Tweening;
using FD.Dev;

public class SklChaceState : FAED_FSMState
{

    [SerializeField] private bool reverce;
    [SerializeField] private Vector2 size;
    [SerializeField] private Vector2 offset;
    [SerializeField] private LayerMask layerMask;

    private EnemyMovementHide hide;
    private float speed => hide.getMoveSpeed;
    private Rigidbody2D rigid;
    private Transform player;
    private GroundCol groundCol;
    private bool jumpCoolDown = true;

    private void Awake()
    {

        player = GameObject.Find("Player").transform;
        rigid = transform.parent.GetComponent<Rigidbody2D>();
        hide = transform.parent.GetComponent<EnemyMovementHide>();
        groundCol = transform.parent.GetComponentInChildren<GroundCol>();

    }

    public override void EnterState()
    {


    }

    public override void UpdateState()
    {
        float value = 0;
        if (!reverce)
        {

            value = player.position.x > transform.position.x ? speed : -speed;

        }
        else
        {

            value = player.position.x > transform.position.x ? -speed : speed;

        }

        rigid.velocity = new Vector2(value, rigid.velocity.y);

        var obj = Physics2D.OverlapBox(transform.position + (Vector3)offset, size, 0, layerMask);

        if(obj != null && groundCol.isGround && jumpCoolDown) 
        {

            jumpCoolDown = false;
            rigid.velocity += new Vector2(0, 5f);
            FAED.InvokeDelay(() =>
            {

                jumpCoolDown = true;

            }, 1f) ;

        }

    }

    public override void ExitState()
    {
        
        rigid.velocity = Vector2.zero;

    }


}
