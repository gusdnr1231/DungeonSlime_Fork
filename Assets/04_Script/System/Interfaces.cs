using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interface
{

    public interface IEventObject
    {

        public void AddEvent();
        public void RemoveEvent();

    }

    public interface IMoveAbleObject
    {

        public bool moveAble { get; set; }
        public void SetValMoveAble();

    }

    public interface IAIState
    {

        public AITransition transition { get; set; }
        public void SettingState(AIController controller);
        public void UpdateState();
        public void EnterState();
        public void ExitState();

    }

}