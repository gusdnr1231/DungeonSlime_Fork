using Interface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AIController : EnemyRoot
{

    [SerializeField] private AIState currentState;
    [SerializeField] private GameObject aiRootObj;

    private List<AIState> aIStates = null;
    private event Action UpdateEventHandle = null;

    protected override void Awake()
    {

        base.Awake();

        if (aiRootObj == null) GetComponentsInChildren(aIStates);
        else aiRootObj.GetComponentsInChildren(aIStates);

        foreach(var item in aIStates) 
        {

            item.SettingState(this);
        
        }

        AddEvent();

    }

    private void Update()
    {
        
        UpdateEventHandle?.Invoke();

    }

    private void UpdateEvent()
    {

        foreach(var item in aIStates) 
        { 
            
            item.UpdateState();
        
        }

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
