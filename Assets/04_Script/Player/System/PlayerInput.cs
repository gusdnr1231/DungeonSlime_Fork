using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public float moveValue;

    public event Action<float> OnMovementEvent;
    public event Action<bool> OnJumpKeyPressEvent;
    public event Action OnJumpEvent;
    public event Action OnBounceEvent;
    public event Action OnHideEvnet;
    public event Action OnSkillEvent;
    public event Action OnUpdateEvent;

    public bool controllAble { get; set; } = true;

    private void FixedUpdate()
    {

        if (!controllAble) return;

        OnMovementEvent?.Invoke(moveValue);

    }

    private void Update()
    {

        if (!controllAble) return;

        OnUpdateEvent?.Invoke();

    }

    public void SetMoveValue(float v)
    {

        if (!controllAble) return;
        moveValue = v;

    }

    public void JumpExecute()
    {

        if (!controllAble) return;

        OnJumpEvent?.Invoke();

    }

    public void BounceExecute()
    {

        if (!controllAble) return;

        OnBounceEvent?.Invoke();    

    }

    public void HideExecute()
    {

        if (!controllAble) return;

        OnHideEvnet?.Invoke();

    }

    public void SkillExecute()
    {

        if (!controllAble) return;

        OnSkillEvent?.Invoke();

    }

    public void JumpKeyPressExecute(bool b)
    {

        if (!controllAble) return;

        OnJumpKeyPressEvent?.Invoke(b);

    }

}
