using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerMovementRoot
{
    [SerializeField] private float JumpPower;
    [SerializeField] private float DoubleJumpPower;
    public bool jumpAble { get; set; } = true;

    public bool canDoubleJump = true;

    protected override void Awake()
    {

        base.Awake();

        AddEvent();

    }

    private void Jump()
    {
        if (jumpAble == false || Physics2D.OverlapBox(transform.position, new Vector2(1, 1), 0, LayerMask.GetMask("JumpPad"))) return;
        if (groundCol.isGround == false && canDoubleJump == false) return;

        AudioManager.Instance.PlayAudio("PlayerJump", audioSource);
        if (groundCol.isGround == true)
        {
            rigid.velocity += Vector2.up * JumpPower;
            canDoubleJump = true;
        }
        else if (canDoubleJump == true)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, DoubleJumpPower);
            canDoubleJump = false;
        }

        

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
