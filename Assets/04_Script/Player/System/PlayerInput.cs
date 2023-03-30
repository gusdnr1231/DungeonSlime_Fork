using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private float moveValue;

    public event Action<float> OnMovementEvent;
    public event Action OnJumpEvent;
    public event Action OnBounceEvent;
    public event Action OnHideEvnet;
    public event Action OnSkillEvent;

    private void Update()
    {

        OnMovementEvent?.Invoke(moveValue);

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

}
