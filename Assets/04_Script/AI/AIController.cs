using Interface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AIController : EnemyRoot
{

    [SerializeField] private AIState currentState;
    [SerializeField] private GameObject aiRootObj;

    private event Action UpdateEventHandle = null;

    protected override void Awake()
    {

        base.Awake();


        foreach(var item in aiRootObj.GetComponentsInChildren<AIState>()) 
        {

            item.SettingState(this);
        
        }

        AddEvent();

    }

    private void Start()
    {
        
        currentState.EnterState();

    }

    private void Update()
    {
        
        UpdateEventHandle?.Invoke();

    }

    private void UpdateEvent()
    {

        currentState.UpdateState();

        if (currentState.transition.Chack())
        {

            ChangeState(currentState.transition.nextState);

        }

    }

    private void ChangeState(AIState state)
    {

        currentState.ExitState();
        currentState = state;
        currentState.EnterState();

    }

    public override void AddEvent()
    {

        UpdateEventHandle += UpdateEvent;

    }

    public override void RemoveEvent() 
    {

        UpdateEventHandle -= UpdateEvent;

    }

}
