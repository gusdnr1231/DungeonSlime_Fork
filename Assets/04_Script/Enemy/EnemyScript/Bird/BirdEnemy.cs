using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemy : EnemyRoot
{
    [SerializeField] private float jummpPower;
    private int jumpCnt = 4;
    private Rigidbody2D rb;

    protected override void Awake()
    {
        base.Awake();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Fly()
    {
        if (jumpCnt >= 0)
        {
            jumpCnt--;
            rb.velocity = Vector3.up * jummpPower;
        }

        if (groundCol.isGround)
            jumpCnt = 4;
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
