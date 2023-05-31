using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAnimator : MonoBehaviour
{

    private readonly int DieTriggerHash = Animator.StringToHash("Die");

    private Rigidbody2D rigid;
    private Animator animator;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {

        animator.SetBool("R", Mathf.Abs(rigid.velocity.x) <= 0);

    }

    public void SetDieTrigger() => animator.SetTrigger(DieTriggerHash);

}
