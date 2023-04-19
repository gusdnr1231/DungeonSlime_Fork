using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPipeUse : PlayerMovementRoot
{
    [SerializeField] private Vector2 boxRange;
    [SerializeField] private LayerMask pipeLayer;

    private PlayerJump jump;
    private bool isInSidePipe;

    protected override void Awake()
    {

        base.Awake();
        AddEvent();
        jump = GetComponent<PlayerJump>();

    }

    private void UsingPipe()
    {

        RaycastHit2D hitAble = Physics2D.BoxCast(transform.position, boxRange, 0, Vector2.zero, 0, pipeLayer);

        if(hitAble && hitAble.transform.TryGetComponent<Pipe>(out var pipe))
        {

            isInSidePipe = true;
            RemoveEvent();
            pipe.UsePipe(transform, AddEvent);

        }

    }

    public override void AddEvent()
    {

        if (!isInSidePipe) return;

        input.OnHideEvnet += UsingPipe;
        jump?.AddEvent();
        isInSidePipe = false;

    }

    public override void RemoveEvent() 
    {
        if (!isInSidePipe) return;
        input.OnHideEvnet -= UsingPipe;
        jump?.RemoveEvent();

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {

        Color old = Gizmos.color;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, boxRange);
        Gizmos.color=old;

    }

#endif

}
