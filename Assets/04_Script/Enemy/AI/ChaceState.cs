using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.AI.FSM;
using DG.Tweening;

public class ChaceState : FAED_FSMState
{

    [SerializeField] private bool reverce;

    private EnemyMovementHide hide;
    private float speed => hide.getMoveSpeed;
    private Rigidbody2D rigid;
    private Transform player;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {

        player = GameObject.Find("Player").transform;
        rigid = transform.parent.GetComponent<Rigidbody2D>();
        hide = transform.parent.GetComponent<EnemyMovementHide>();
        spriteRenderer = transform.parent.GetComponent<SpriteRenderer>();

    }

    public override void EnterState()
    {


    }

    public override void UpdateState()
    {
        float value;
        if (!reverce)
        {

            value = player.position.x > transform.position.x ? speed : -speed;

        }
        else
        {

            value = player.position.x > transform.position.x ? -speed : speed;

        }

        if (value > 0)
            spriteRenderer.flipX = true;
        else if (value < 0)
            spriteRenderer.flipX = false;

        rigid.velocity = new Vector2(value, rigid.velocity.y);

    }

    public override void ExitState()
    {
        
        rigid.velocity = Vector2.zero;

    }

}
