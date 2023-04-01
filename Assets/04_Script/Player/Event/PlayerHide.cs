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
    private bool isHide;

    protected override void Awake()
    {

        base.Awake();
        input.OnHideEvnet += Hide;
        input.OnBounceEvent += Bounce;

        playerEvent = GetComponents<IEventObject>().ToList();

    }

    private void Hide()
    {

        if (isHide) return;

        RaycastHit2D hitAble = Physics2D.BoxCast(transform.position, boxRange, 0, Vector2.zero, 0, enemyLayer);

        if (hitAble == false) return;

        foreach(var x in playerEvent)
        {

            x.RemoveEvent();

        }

        foreach(var x in hitAble.transform.GetComponents<IEventObject>())
        {

            x.AddEvent();

        }

        spriteRenderer.enabled = false;
        playerCollider.enabled = false;
        rigid.gravityScale = 0;
        

        isHide = true;

    }

    private void Bounce()
    {

        if(!isHide) return;

        foreach (var x in playerEvent)
        {

            x.AddEvent();

        }

        spriteRenderer.enabled = true;

        isHide = false;

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        
        Gizmos.DrawWireCube(transform.position, boxRange);

    }

#endif

}
