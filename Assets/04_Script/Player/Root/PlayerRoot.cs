using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoot : MonoBehaviour
{

    protected PlayerInput input;
    protected Rigidbody2D rigid;
    protected GroundCol groundCol;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;

    protected virtual void Awake()
    {

        input = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        groundCol = FindObjectOfType<GroundCol>();

    }

}
