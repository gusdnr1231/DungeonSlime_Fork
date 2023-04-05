using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffBlockAnimator : MonoBehaviour
{

    private readonly int IsOnHash = Animator.StringToHash("IsOn");

    private Animator animator;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();

    }

    public void SetIsOn(bool isOn)
    {

        animator.SetBool(IsOnHash, isOn);

    }

}
