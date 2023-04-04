using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : EnemyRoot
{
    private Rigidbody2D rb;

    protected override void Awake()
    {

        base.Awake();
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        Debug.Log(rb.gameObject);
    }

    private void AngleSetting(float value)
    {
        transform.Rotate(0, 0, -value);
    }

    private void Fire()
    {
        input.BounceExecute();
        rb.AddForce(new Vector2(500, 9) * 10);
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
