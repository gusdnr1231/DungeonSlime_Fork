using FD.AI.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : FAED_FSMState
{

    [SerializeField] private float changeTime;

    private EnemyMovementHide movementHide;
    private float movementSpeed => movementHide.getMoveSpeed;
    private float dir = 1;
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        
        rigid = transform.parent.GetComponent<Rigidbody2D>();
        movementHide = transform.parent.GetComponent<EnemyMovementHide>();
        spriteRenderer = transform.parent.GetComponent<SpriteRenderer>();

    }

    public override void EnterState()
    {

        StartCoroutine(DirChangeCo());

    }

    public override void ExitState()
    {

        StopAllCoroutines();

    }

    public override void UpdateState()
    {

        spriteRenderer.flipX = dir >= 0 ? true : false;   
        rigid.velocity = new Vector2(movementSpeed * dir, rigid.velocity.y);

    }

    IEnumerator DirChangeCo()
    {

        while (true)
        {

            yield return new WaitForSeconds(changeTime);
            dir *= -1;

        }

    }

}
