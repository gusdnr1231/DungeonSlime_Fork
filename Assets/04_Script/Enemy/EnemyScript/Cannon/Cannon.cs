using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : EnemyRoot
{
    private Rigidbody2D rb;
    EnemyMovementHide movementHide;

    protected override void Awake()
    {

        base.Awake();
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        movementHide = gameObject.GetComponent<EnemyMovementHide>();
    }

    private void AngleSetting(float value)
    {
        transform.Rotate(0, 0, -value);
    }

    private void Fire()
    {
        input.BounceExecute();
        movementHide.SetValMoveAble();
        rb.velocity += new Vector2(5, 5) * 2;
        // rb.AddForce(new Vector2(50, 9) * 10);
        movementHide.SetValMoveAble();
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
