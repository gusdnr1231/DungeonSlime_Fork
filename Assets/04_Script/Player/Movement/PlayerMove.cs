using Struct;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerMovementRoot
{

    [SerializeField] private float moveSpeed;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

    }

    private void Move(float value)
    {

        rigid.velocity = new Vector2(value * moveSpeed, rigid.velocity.y);

    }

    public override void AddEvent()
    {
        
        input.OnMovementEvent += Move;

    }

    public override void RemoveEvent() 
    {

        input.OnMovementEvent -= Move;

    }

}
