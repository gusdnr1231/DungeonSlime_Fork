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
    private bool isHideAnimation;

    private PlayerMove playerMove;
    private PlayerJump playerJump;

    protected override void Awake()
    {

        base.Awake();

        playerMove = GetComponent<PlayerMove>();
        playerJump = GetComponent<PlayerJump>();

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
        isHideAnimation = true;
        isHide = true;
        // 흡수 애니메이션 재생
        StartCoroutine(HideCo(hitAble));

    }

    IEnumerator HideCo(RaycastHit2D hitAble)
    {
        // 사운드
        AudioManager.Instance.PlayAudio("PlayerHide", audioSource);

        // 애니메이션
        playerMove.moveAble = false;
        playerJump.jumpAble = false;

        animator.SetBool("IsHide", true);
        animator.SetTrigger("Hide");
        yield return new WaitForSeconds(0.4f);
        playerMove.moveAble = true;
        playerJump.jumpAble = true;

        animator.SetBool("IsHide", false);
        animator.ResetTrigger("Hide");

        foreach (var x in playerEvent)
        {

            x.RemoveEvent();

        }

        foreach (var x in hitAble.transform.GetComponents<IEventObject>())
        {

            x.AddEvent();

        }

        spriteRenderer.enabled = false;
        playerCollider.enabled = false;
        rigid.gravityScale = 0;

        rigid.velocity = Vector3.zero;

        var evt = enemyObj.GetComponent<DieEvent>();
        if (evt != null) evt.dieEvt += Bounce;

        CameraManager.instance?.CameraTarget(enemyObj.transform.Find("BouncePos"));

        isHideAnimation = false;
    }

    private void Bounce()
    {

        if(!isHide || isHideAnimation) return;


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

        var jumpPos = enemyObj.transform.Find("BouncePos");
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
