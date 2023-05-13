using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{

    [SerializeField] private List<AIDecision> decisions = new List<AIDecision>();

    public AIState nextState;

    public bool Chack()
    {

        foreach(var item in decisions)
        {

            if(item.MakeDecision()) return true;
                
        }

        return false;

    }

}
