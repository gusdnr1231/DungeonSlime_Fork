using Interface;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerHide : PlayerRoot
{

    [SerializeField] private Vector2 boxRange;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float bouncePower;

    private List<IEventObject> playerEvent = new List<IEventObject>();
    private GameObject enemyObj;
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

        enemyObj = hitAble.transform.gameObject;


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
        
        rigid.velocity = Vector3.zero;

        var evt = enemyObj.GetComponent<DieEvent>();
        if(evt != null) evt.dieEvt += Bounce;

        CameraManager.instance?.CameraTarget(enemyObj.transform.Find("BouncePos"));

        isHide = true;

    }

    private void Bounce()
    {

        if(!isHide) return;

        var jumpPos = enemyObj.transform.Find("BouncePos");

        if(Physics2D.OverlapBox(jumpPos.position + new Vector3(0, 1), new Vector2(0.8f, 1), 0, LayerMask.GetMask("Ground"))) 
        {

            return;

        }

        foreach (var x in playerEvent)
        {
            x.AddEvent();
        }

        foreach (var x in enemyObj.GetComponents<IEventObject>())
        {

            x.RemoveEvent();

        }

        spriteRenderer.enabled = true;
        playerCollider.enabled = true;
        rigid.gravityScale = 1;

        var evt = enemyObj.GetComponent<DieEvent>();
        if(evt != null) evt.dieEvt -= Bounce;

        transform.position = jumpPos.position;

        rigid.velocity += Vector2.up * bouncePower;

        CameraManager.instance?.CameraTarget(transform);
        enemyObj = null;

        isHide = false;

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        
        Gizmos.DrawWireCube(transform.position, boxRange);

    }

#endif

}
