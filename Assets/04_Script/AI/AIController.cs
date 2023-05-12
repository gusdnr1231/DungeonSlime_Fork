using Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : EnemyRoot
{

    [SerializeField] private GameObject aiRootObj;

    private List<IAIState> aIStates = null;

    protected override void Awake()
    {

        base.Awake();

        if (aiRootObj == null) GetComponentsInChildren(aIStates);
        else GetComponentsInChildren(aIStates);

    }

}
