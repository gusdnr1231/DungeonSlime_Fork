using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Struct
{

    [System.Serializable]
    public struct InputObject
    {

        public UnityEvent inputEvent;
        public KeyCode keyCode;

    }

    [System.Serializable]
    public struct EnemyData
    {

        [field:SerializeField] public float speed { get; private set; }
        [field:SerializeField] public float jumpPower { get; private set; }

    }

    [System.Serializable]
    public struct SaveData
    {

        
    }

}
