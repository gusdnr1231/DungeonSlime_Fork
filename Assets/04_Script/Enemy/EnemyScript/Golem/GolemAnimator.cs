using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAnimator : MonoBehaviour
{

    private readonly int DieTriggerHash = Animator.StringToHash("Die");

    private Animator animator;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();

    }

    public void SetDieTrigger() => animator.SetTrigger(DieTriggerHash);

}
