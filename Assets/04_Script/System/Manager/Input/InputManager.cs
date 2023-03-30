using Struct;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{

    [Header("__GetKey__")]
    [SerializeField] private List<InputObject> keyInputObjects = new List<InputObject>();
    [Header("__GetKeyUp__")]
    [SerializeField] private List<InputObject> keyUpInputObjects = new List<InputObject>();
    [Header("__GetKeyDown__")]
    [SerializeField] private List<InputObject> keyDownInputObjects = new List<InputObject>();
    [Header("Horizontal")]
    [SerializeField] private UnityEvent<float> horInputEvent;

    private void Update()
    {

        if (Managers.SystemManage.isKeyboard == false) return;

        InputEvent();

    }

    private void InputEvent()
    {

        foreach (var inputObject in keyInputObjects) 
        {

            if (Input.GetKey(inputObject.keyCode)) inputObject.inputEvent?.Invoke();

        }

        foreach (var inputObject in keyUpInputObjects)
        {

            if (Input.GetKeyUp(inputObject.keyCode)) inputObject.inputEvent?.Invoke();

        }

        foreach (var inputObject in keyDownInputObjects)
        {

            if (Input.GetKeyDown(inputObject.keyCode)) inputObject.inputEvent?.Invoke();

        }

        horInputEvent?.Invoke(Input.GetAxisRaw("Horizontal"));

    }

}
