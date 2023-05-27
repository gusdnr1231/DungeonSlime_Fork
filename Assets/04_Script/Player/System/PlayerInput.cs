using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private float moveValue;

    public event Action<float> OnMovementEvent;
    public event Action<bool> OnJumpKeyPressEvent;
    public event Action OnJumpEvent;
    public event Action OnBounceEvent;
    public event Action OnHideEvnet;
    public event Action OnSkillEvent;
    public event Action OnUpdateEvent;

    private void FixedUpdate()
    {

        OnMovementEvent?.Invoke(moveValue);

    }

    private void Update()
    {

        OnUpdateEvent?.Invoke();

    }

    public void SetMoveValue(float v)
    {

        moveValue = v;

    }

    public void JumpExecute()
    {

        OnJumpEvent?.Invoke();

    }

    public void BounceExecute()
    {

        OnBounceEvent?.Invoke();    

    }

    public void HideExecute()
    {

        OnHideEvnet?.Invoke();

    }

    public void SkillExecute()
    {

        OnSkillEvent?.Invoke();

    }

    public void JumpKeyPressExecute(bool b)
    {
        
        OnJumpKeyPressEvent?.Invoke(b);

    }

}
