using Cinemachine;
using DG.Tweening;
using FD.AI.FSM;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class HitPunch : FAED_FSMTransition
{
    [Header("Object")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject skullBoss;
    [SerializeField] private Transform popPoint;
    [Header("Other")]
    [SerializeField] private CinemachineVirtualCamera cv;

    private SkulBossAppear bossAppear;
    private Rigidbody2D skbRg;
    private Animator skbAnim;

    protected override void Awake()
    {

        base.Awake();

        bossAppear = transform.parent.parent.GetComponent<SkulBossAppear>();
        skbRg = transform.parent.parent.GetComponent<Rigidbody2D>();
        skbAnim = transform.parent.parent.GetComponent<Animator>();
    }

    public override bool ChackTransition()
    {
        Debug.Log("hit");
        if (Physics2D.OverlapBox(skullBoss.transform.position, new Vector2(2f, 5.5f), 0, LayerMask.GetMask("Hand")))
        {
            cv.Follow = player.transform;
            cv.m_Lens.OrthographicSize = 8;

            skbAnim.enabled = true;
            skbRg.constraints |= RigidbodyConstraints2D.FreezePosition;

            BossHP.Instance.Hit();

            if (BossHP.Instance.Boss_hp <= 0)
            {
                player.transform.position = popPoint.transform.position;
                player.SetActive(true);
            }

            if (BossHP.Instance.Boss_hp > 0)
            {
                skullBoss.transform.DOMove(new Vector2(-1.4f, bossAppear.backPos), 1f).SetEase(Ease.OutBack)
                .OnComplete(() =>
                {
                    player.transform.position = popPoint.transform.position;
                    player.SetActive(true);
                });
            }

            return true;
        }
        return false;
    }
}
