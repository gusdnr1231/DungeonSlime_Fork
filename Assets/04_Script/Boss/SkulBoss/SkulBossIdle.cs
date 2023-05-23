using DG.Tweening;
using FD.AI.FSM;
using FD.AI.Tree.Program;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkulBossIdle : FAED_FSMState
{
    [Header("GameObject")]
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;
    [Space(10f)]
    [SerializeField] private Transform leftPos;
    [SerializeField] private Transform rightPos;
    [SerializeField] private GameObject dangerousBox;
    [Header("Values")]
    [SerializeField] private BoxCollider2D onPlayer;
    [SerializeField] private Vector2 maxX;
    [SerializeField] private Vector2 maxY;
    [SerializeField] private float attackSpeed;

    private SkulBossAppear bossAppear;
    private GameObject player;

    Color orignDangerousColor;

    Sequence attack;

    void Awake()
    {
        bossAppear = FindObjectOfType<SkulBossAppear>();
        orignDangerousColor = dangerousBox.GetComponent<SpriteRenderer>().color;
        dangerousBox.SetActive(false);
        player = FindObjectOfType<PlayerAnimator>().gameObject;

        leftHand.GetComponent<Collider2D>().enabled = false;
        rightHand.GetComponent<Collider2D>().enabled = false;
    }

    private void Start()
    {
        attack = DOTween.Sequence();

        attack.Append(leftHand.transform.DOMove(new Vector3(maxX.x, PlayerValue(), 0), 1f).SetEase(Ease.OutCirc))
        .Join(rightHand.transform.DOMove(new Vector3(maxX.y, PlayerValue(), 0), 1f).SetEase(Ease.OutCirc))
        .AppendCallback(() =>
        {
            leftHand.GetComponent<Collider2D>().enabled = true;
            rightHand.GetComponent<Collider2D>().enabled = true;

            rightHand.transform.eulerAngles += new Vector3(0, 0, -90);
            Attack(leftHand, -90);
        });
    }

    void Attack(GameObject hand, float angle)
    {
        hand.transform.eulerAngles += new Vector3(0, 0, angle);

        dangerousBox.GetComponent<SpriteRenderer>().color = orignDangerousColor;
        dangerousBox.transform.position = new Vector2(dangerousBox.transform.position.x, hand.transform.position.y);
        dangerousBox.SetActive(true);
        dangerousBox.GetComponent<SpriteRenderer>().DOFade(0, 1.5f)
        .OnComplete(() =>
        {
            hand.transform.DOMoveX(-hand.transform.position.x, attackSpeed).SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                hand.transform.DOMoveY(PlayerValue(), 0.5f);

                if (hand == leftHand) Attack(rightHand, 180);
                else Attack(leftHand, 180);
            });
        });
    }

    float PlayerValue()
    {
        return Mathf.Clamp(player.transform.position.y, -10, bossAppear.backPos - 4f);
    }

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        
    }

    public override void ExitState()
    {
        StopAllCoroutines();
    }
}
