using Interface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AIController : EnemyRoot
{

    [SerializeField] private GameObject aiRootObj;

    private List<IAIState> aIStates = null;
    private event Action UpdateEventHandle = null;

    protected override void Awake()
    {

        base.Awake();

        if (aiRootObj == null) GetComponentsInChildren(aIStates);
        else GetComponentsInChildren(aIStates);

        AddEvent();

    }


    private void Update()
    {
        
        UpdateEventHandle?.Invoke();

    }

    private void UpdateEvent()
    {



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
