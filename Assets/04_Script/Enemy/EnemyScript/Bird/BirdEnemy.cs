using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemy : EnemyRoot
{
    [SerializeField] private float jummpPower;
    Rigidbody2D rb;

    protected override void Awake()
    {
        base.Awake();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Fly()
    {
        rb.velocity = Vector3.up * jummpPower;
    }

    public override void AddEvent()
    {

        input.OnJumpEvent += Fly;

    }

    public override void RemoveEvent()
    {

        input.OnJumpEvent -= Fly;

    }
}
