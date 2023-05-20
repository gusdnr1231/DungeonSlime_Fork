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

    private void Awake()
    {
        
        animator = GetComponent<Animator>();
        groundCol = GetComponentInChildren<GroundCol>();

    }

}
