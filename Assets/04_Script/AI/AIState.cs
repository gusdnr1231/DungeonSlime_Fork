using Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState : IAIState
{
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public virtual void SettingState(AIController controller)
    {



    }

}
