using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : EnemyRoot
{
    [SerializeField] private Vector2 size, pos;
    private Rigidbody2D rb;

    protected override void Awake()
    {
        base.Awake();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void WallSide(float value)
    {
        if (Physics2D.BoxCast(transform.position + (Vector3)pos, size, 0, Vector2.zero, 0,LayerMask.GetMask("Ground", "Enemy")))
        {
            if (value != 0)
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, 2f);
            }
            else rb.gravityScale = 1;
        }
        else rb.gravityScale = 1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + (Vector3)pos, size);
    }

    public override void AddEvent()
    {

        input.OnMovementEvent += WallSide;

    }

    public override void RemoveEvent()
    {

        input.OnMovementEvent -= WallSide;

    }
}
