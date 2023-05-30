using FD.AI.FSM;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemDieEvt : DieEvent
{

    private GolemAnimator animator;
    private FAED_FSM fsm;

    private void Awake()
    {
        
        animator = GetComponent<GolemAnimator>();
        fsm = GetComponent<FAED_FSM>();

    }

    public override void Die()
    {

        fsm.AddEvent();
        Execute();
        animator.SetDieTrigger();

    }

    public void SummonDieBlock()
    {

        if (GetComponent<DieSensor>().dieTag == "Water")
        {

            FAED.Pop("GolemBlock", transform.position, Quaternion.identity).GetComponent<GolemDieBlock>().Setting();

        }
        else
        {

            FAED.Pop("GolemBlock", transform.position, Quaternion.identity).GetComponent<GolemDieBlock>().Setting();

        }

        gameObject.SetActive(false);

    }

}
