using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpHide : EnemyRoot
{

    [SerializeField] private float jumpPower;
    public float JumpPower => jumpPower;
    private void Jump()
    {

        if (groundCol.isGround == false) return;

        rigid.velocity += Vector2.up * jumpPower;

    }

    public override void AddEvent()
    {

        input.OnJumpEvent += Jump;

    }

    public override void RemoveEvent()
    {

        input.OnJumpEvent -= Jump;

    }

}
