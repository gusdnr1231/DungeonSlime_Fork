using Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : EnemyRoot
{

    [SerializeField] private GameObject aiRootObj;

    private IAIState[] aIStates = null;

    protected override void Awake()
    {

        base.Awake();

        if (aiRootObj == null) aIStates = GetComponentsInChildren<IAIState>();
        else aIStates = aiRootObj.GetComponentsInChildren<IAIState>();

    }

}
