using Struct;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerRoot
{

    [SerializeField] private float moveSpeed;

    protected override void Awake()
    {

        base.Awake();

        input.OnMovementEvent += Move;

    }

    private void Move(float value)
    {

        rigid.velocity = new Vector2(value * moveSpeed, rigid.velocity.y);

    }


}
