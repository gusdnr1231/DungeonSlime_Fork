using FD.Dev;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemDieBlock : MonoBehaviour
{


    private Animator animator;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();

    }

    public void Setting()
    {

        FAED.InvokeDelayReal(() =>
        {

            animator.SetTrigger("Set");

        }, 8f);

    }


    public void Summon()
    {

        Instantiate(Resources.Load("Enemy/Golem"), transform.position, Quaternion.identity);
        gameObject.SetActive(false);

    }

}
