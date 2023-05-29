using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : PlayerRoot
{

    private readonly int IsGroundHash = Animator.StringToHash("IsGround");
    private readonly int IsMoveHash = Animator.StringToHash("IsMove");
    private readonly int YVelHash = Animator.StringToHash("YVel");

    private void Update()
    {

        SetMove();
        SetGround();
        SetYVel();
    }

    private void SetMove()
    {

        bool move = rigid.velocity.x switch
        {

            0 => false,
            _ => true

        };

        animator.SetBool(IsMoveHash, move);

    }

    private void SetGround()
    {

        animator.SetBool(IsGroundHash, groundCol.isGround);

    }

    private void SetYVel()
    {

        animator.SetFloat(YVelHash, rigid.velocity.y);

    }

}
