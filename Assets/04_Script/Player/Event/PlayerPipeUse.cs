using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPipeUse : PlayerMovementRoot
{
    [SerializeField] private Vector2 boxRange;
    [SerializeField] private LayerMask pipeLayer;

    protected override void Awake()
    {

        base.Awake();
        AddEvent();

    }

    private void UsingPipe()
    {

        RaycastHit2D hitAble = Physics2D.BoxCast(transform.position, boxRange, 0, Vector2.zero, 0, enemyLayer);

        if(hitAble && hitAble.transform.TryGetComponent<Pipe>(out var pipe))
        {

            RemoveEvent();
            pipe.UsePipe(transform, AddEvent);

        }

    }

    public override void AddEvent()
    {

        input.OnHideEvnet += UsingPipe;

    }

    public override void RemoveEvent() 
    {

        input.OnHideEvnet -= UsingPipe;

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
