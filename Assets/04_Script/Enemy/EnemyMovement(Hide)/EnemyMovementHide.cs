using Interface;
using Struct;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementHide : EnemyRoot, IMoveAbleObject
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float increseMoveSpeed;
    [SerializeField] private float maxMoveSpeed;

    private float addMoveSpeed;

    public bool moveAble { get; set; } = true;
    public float getMoveSpeed => moveSpeed;

    private void Move(float value)
    {
        if (!moveAble) return;

        if (value == 0)
        {
            addMoveSpeed = 1;
        }
        if (addMoveSpeed <= maxMoveSpeed) addMoveSpeed += increseMoveSpeed / 100f;

        spriteRenderer.flipX = value == 1 ? true : false;

        rigid.velocity = new Vector2(value * moveSpeed * addMoveSpeed, rigid.velocity.y);

    }

    public void NewMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }


    public void SetValMoveAble()
    {

        StopAllCoroutines();
        StartCoroutine(SetMoveAbleToVelCo());
        
    }

    public override void AddEvent()
    {

        input.OnMovementEvent += Move;

    }

    public override void RemoveEvent() 
    {

        input.OnMovementEvent -= Move;

    }

    IEnumerator SetMoveAbleToVelCo()
    {

        moveAble = false;

        yield return new WaitUntil(() =>
        {

            return rigid.velocity == Vector2.zero;

        });

        moveAble = true;

    }

}
