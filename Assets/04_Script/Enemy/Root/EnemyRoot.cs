using Interface;
using Struct;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoot : MonoBehaviour, IEventObject
{

    protected PlayerInput input;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected Rigidbody2D rigid;
    protected GroundCol groundCol;
    protected bool isHidingPlayer;

    protected virtual void Awake()
    {

        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        groundCol = GetComponentInChildren<GroundCol>();

        input = FindObjectOfType<PlayerInput>();

    }

    public virtual void Hide() 
    {

        AddEvent();

    }

    public virtual void Bounce() 
    { 
        
        RemoveEvent();

    }

    public virtual void AddEvent()
    {
    }

    public virtual void RemoveEvent()
    {
    }
}
