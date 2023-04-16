using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.AI.FSM;
using DG.Tweening;

public class ChaceState : FAED_FSMState
{

    private Rigidbody2D rigid;
    private Transform player;

    private void Awake()
    {

        player = GameObject.Find("Player").transform;
        rigid = transform.parent.GetComponent<Rigidbody2D>();

    }

    public override void EnterState()
    {


    }

    public override void UpdateState()
    {
        
        float value = player.position.x > transform.position.x ? -3f : 3f;

        rigid.velocity = new Vector2(value, rigid.velocity.y);

    }

    public override void ExitState()
    {
        
        rigid.velocity = Vector2.zero;

    }

}
