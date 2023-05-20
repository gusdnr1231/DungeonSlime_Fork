using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellAnimator : MonoBehaviour
{
    
    private Animator animator;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();

    }

}
