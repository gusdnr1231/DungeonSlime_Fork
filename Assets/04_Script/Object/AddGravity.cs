using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGravity : PlayerMovementRoot
{

    private const float gravityValue = 9.8f;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

    }

    private void GravityAdd()
    {

        if (!groundCol.isGround)
        {

            rigid.velocity -= Vector2.up * gravityValue * Time.deltaTime;

        }

    }

    public override void AddEvent()
    {

        input.OnUpdateEvent += GravityAdd;

    }

    public override void RemoveEvent() 
    {

        input.OnUpdateEvent -= GravityAdd;

    }

}
