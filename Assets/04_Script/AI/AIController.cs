using Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : EnemyRoot
{

    [SerializeField] private GameObject aiRootObj;

    private List<IAIState> aIStates = null;
    private event Action UpdateEvent = null;

    protected override void Awake()
    {

        base.Awake();

        if (aiRootObj == null) GetComponentsInChildren(aIStates);
        else GetComponentsInChildren(aIStates);

        AddEvent();

    }

    public override void AddEvent()
    {



    }

    public override void RemoveEvent() 
    { 
    
        

    }

}
