using FD.AI.FSM;
using Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skell : EnemyRoot
{

    [SerializeField] private EnemyRoot[] eventObjects;

    private FAED_FSM fsm;
    private DieEvent dieEvent;
    private SkellAnimator sklAnimator;

    protected override void Awake()
    {

        dieEvent = GetComponent<DieEvent>();
        fsm = GetComponent<FAED_FSM>();
        sklAnimator = GetComponent<SkellAnimator>();

    }

    public override void AddEvent()
    {

        StartCoroutine(AdCo());
        
        foreach(var item in eventObjects) 
        { 
            
            item.RemoveEvent();
        
        }

        
        sklAnimator.SetPaintTrigger(true);

    }

    public override void RemoveEvent()
    {
    }

    private IEnumerator AdCo()
    {

        yield return null;
        dieEvent.Die();
        fsm.AddEvent();

    }

}
