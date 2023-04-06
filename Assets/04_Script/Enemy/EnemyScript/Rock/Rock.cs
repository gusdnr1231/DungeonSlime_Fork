using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : EnemyRoot
{
    private Rigidbody2D rb;
    EnemyMovementHide movementHide;

    protected override void Awake()
    {
        base.Awake();
        rb = gameObject.GetComponent<Rigidbody2D>();
        movementHide = gameObject.GetComponent<EnemyMovementHide>();
    }

    private void NotClamp(float value)
    {
        rb.mass = 10;
    }

    public override void AddEvent()
    {

        input.OnMovementEvent += NotClamp;

    }

    public override void RemoveEvent()
    {

        rb.mass = 20;

        input.OnMovementEvent -= NotClamp;

    }
}
