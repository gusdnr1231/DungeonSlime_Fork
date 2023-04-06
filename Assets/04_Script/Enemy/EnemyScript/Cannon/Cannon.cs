using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : EnemyRoot
{
    private Rigidbody2D rb;
    PlayerMove playerMove;

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

        float angle = transform.eulerAngles.z < 180 ? -transform.eulerAngles.z : 360 - transform.eulerAngles.z;
        Debug.Log(angle);

        rb.velocity += new Vector2(angle, 90 - Mathf.Abs(angle)) * 0.1f;
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
