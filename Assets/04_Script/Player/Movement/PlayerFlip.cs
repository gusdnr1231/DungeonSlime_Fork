using Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : PlayerMovementRoot
{

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

    }

    private void Flip(float value)
    {

        spriteRenderer.flipX = value switch
        {

            1 => true,
            2 => false,
            _ => spriteRenderer.flipX

        };

    }

    public override void AddEvent()
    {

        input.OnMovementEvent += Flip;

    }

    public override void RemoveEvent() 
    {

        input.OnMovementEvent -= Flip;

    }

}
