using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{

    [SerializeField] private UnityEvent<float> horInputEvent;

    private void Update()
    {

        if (Managers.SystemManage.isKeyboard == false) return;



    }

}
