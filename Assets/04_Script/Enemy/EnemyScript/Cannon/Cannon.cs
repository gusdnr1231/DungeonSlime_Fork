using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : EnemyRoot
{
    private Rigidbody2D rb;
    PlayerMove playerMove;
    PlayerInput playerInput;

    [SerializeField] private float cannonSpeed = 0.2f;

    protected override void Awake()
    {
        base.Awake();
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        playerMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
    }

    private void AngleSetting(float value)
    {
        transform.Rotate(0, 0, -value);
    }

    private void Fire()
    {
        input.BounceExecute();
        playerMove.SetValMoveAble();
        playerMove.isFlying = true;

        float angle = transform.eulerAngles.z < 180 ? Mathf.Clamp(-transform.eulerAngles.z, -90, 90) : Mathf.Clamp(360 - transform.eulerAngles.z, -90, 90);

        rb.velocity += new Vector2(angle, 90 - Mathf.Abs(angle)) * cannonSpeed;
    }

    public override void AddEvent()
    {

        input.OnMovementEvent += AngleSetting;
        input.OnJumpEvent += Fire;

    }

    public override void RemoveEvent()
    {

        input.OnMovementEvent -= AngleSetting;
        input.OnJumpEvent -= Fire;

    }
}
