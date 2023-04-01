using Interface;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerHide : PlayerRoot
{

    [SerializeField] private Vector2 boxRange;
    [SerializeField] private LayerMask enemyLayer;

    private List<IEventObject> playerEvent = new List<IEventObject>();

    protected override void Awake()
    {

        base.Awake();
        input.OnHideEvnet += Hide;
        input.OnBounceEvent += Bounce;

        playerEvent = GetComponents<IEventObject>().ToList();

    }

    private void Hide()
    {

        RaycastHit2D hitAble = Physics2D.BoxCast(transform.position, boxRange, 0, Vector2.zero, 0, enemyLayer);

        if (hitAble == false) return;

        foreach(var x in playerEvent)
        {

            x.RemoveEvent();

        }

        spriteRenderer.enabled = false;

    }

    private void Bounce()
    {

        foreach (var x in playerEvent)
        {

            x.AddEvent();

        }

        spriteRenderer.enabled = true;

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        
        Gizmos.DrawWireCube(transform.position, boxRange);

    }

#endif

}
