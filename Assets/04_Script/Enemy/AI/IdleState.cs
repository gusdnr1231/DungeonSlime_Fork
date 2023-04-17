using FD.AI.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : FAED_FSMState
{

    [SerializeField] private float movementSpeed;
    [SerializeField] private float changeTime;


    private float dir = 1;
    private Rigidbody2D rigid;

    private void Awake()
    {
        
        rigid = transform.parent.GetComponent<Rigidbody2D>();

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
