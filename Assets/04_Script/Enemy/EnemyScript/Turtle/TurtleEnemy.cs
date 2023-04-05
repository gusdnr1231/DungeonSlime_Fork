using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleEnemy : EnemyRoot
{
    [SerializeField] private string waterTag;
    [SerializeField] private float waterSpeed;
    EnemyMovementHide movementHide;

    protected override void Awake()
    {
        base.Awake();
        movementHide = gameObject.GetComponent<EnemyMovementHide>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag(waterTag))
            movementHide.NewMoveSpeed(waterSpeed);
        else movementHide.NewMoveSpeed(waterSpeed - 2);
    }
}
