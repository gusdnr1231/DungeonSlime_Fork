using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Windows;

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
        //Collider2D col = Physics2D.BoxCast(sideCollider.transform.position, sideCollider.size / 2, 0, LayerMask.GetMask("Ground"));
        if (Physics2D.BoxCast(transform.position + (Vector3)pos, size, 0, Vector2.up, LayerMask.GetMask("Ground")))
        {
            Debug.Log(55);
            if (value != 0)
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, 2f);
            }
        }
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
