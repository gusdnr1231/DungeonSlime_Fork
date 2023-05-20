using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellAnimator : MonoBehaviour
{
    
    //Hash

    //

    private Animator animator;
    private GroundCol groundCol;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();
        groundCol = GetComponentInChildren<GroundCol>();

    }

}
