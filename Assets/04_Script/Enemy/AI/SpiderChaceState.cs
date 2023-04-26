using FD.AI.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderChaceState : FAED_FSMState
{
    [SerializeField] private bool reverce;
    [SerializeField] private Vector2 size, pos;

    private EnemyMovementHide hide;
    private float speed => hide.getMoveSpeed;
    private Rigidbody2D rigid;
    private Transform player;

    private void Awake()
    {

        player = GameObject.Find("Player").transform;
        rigid = transform.parent.GetComponent<Rigidbody2D>();
        hide = transform.parent.GetComponent<EnemyMovementHide>();

    }

    private void Update()
    {
        WallSide();
    }

    private void WallSide()
    {
        if (Physics2D.BoxCast(transform.position + (Vector3)pos, size, 0, Vector2.zero, 0, LayerMask.GetMask("Ground")))
        {
            rigid.gravityScale = 0;
            rigid.velocity = new Vector2(rigid.velocity.x, 2f);
        }
        else rigid.gravityScale = 1;
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

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + (Vector3)pos, size);
    }

    public override void ExitState()
    {

        rigid.gravityScale = 1;
        rigid.velocity = Vector2.zero;

    }
}
