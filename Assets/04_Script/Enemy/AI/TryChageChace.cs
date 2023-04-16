using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.AI.FSM;

public class TryChageChace : FAED_FSMTransition
{

    [SerializeField] private float maxRange;

    public override bool ChackTransition()
    {

        return false;

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        


    }

#endif

}
