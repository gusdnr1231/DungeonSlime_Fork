using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoot : MonoBehaviour
{

    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected Rigidbody2D rigid;

    protected virtual void Awake()
    {

        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

}
