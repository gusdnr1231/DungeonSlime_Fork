using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellAnimator : MonoBehaviour
{

    private readonly int IsMoveHash = Animator.StringToHash("IsMove");
    private readonly int IsAirHash = Animator.StringToHash("IsAir");
    private readonly int JumpTriggerHash = Animator.StringToHash("JumpTrigger");
    private readonly int PaintHash = Animator.StringToHash("Paint");
    private readonly int ReleasePaintHash = Animator.StringToHash("ReleasePaint");

    private Animator animator;
    private GroundCol groundCol;
    private Rigidbody2D rigid;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

        groundCol = GetComponentInChildren<GroundCol>();

    }

    private void Update()
    {
        
        SetIsAir();
        SetIsMove();

    }

    private void SetIsAir() => animator.SetBool(IsAirHash, !groundCol.isGround);
    private void SetIsMove() => animator.SetBool(IsMoveHash, Mathf.Abs(rigid.velocity.x) > 0);

    public void SetJumpTrigger() => animator.SetTrigger(JumpTriggerHash);
    public void SetPaintTrigger(bool value)
    {

        if(value) animator.SetTrigger(PaintHash);
        else animator.SetTrigger(ReleasePaintHash);

    }

}
