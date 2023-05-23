using Cinemachine;
using FD.AI.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : FAED_FSMState
{
    [Header("Object")]
    [SerializeField] private GameObject skullBoss;
    [SerializeField] private Transform popPoint;
    [Header("Other")]
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] float moveSpeed;

    private GameObject player;
    private SkulBossAppear bossAppear;
    private Rigidbody2D skbRg;
    private SpriteRenderer skbSp;
    private Animator skbAnim;
    private CinemachineVirtualCamera cv;

    bool hit;

    void Awake()
    {
        player = FindObjectOfType<PlayerAnimator>().gameObject;
        bossAppear = FindObjectOfType<SkulBossAppear>();
        skbRg = skullBoss.GetComponent<Rigidbody2D>();
        skbSp = skullBoss.GetComponent<SpriteRenderer>();
        skbAnim = skullBoss.GetComponent<Animator>();
        cv = FindObjectOfType<CinemachineVirtualCamera>();
    }

    public override void EnterState()
    {
        Debug.Log("¾¾¹ß¼½½ºdd");
        player.SetActive(false);
        skbRg.constraints &= ~RigidbodyConstraints2D.FreezePosition;
        cv.Follow = skullBoss.transform;
        cv.m_Lens.OrthographicSize = 9;
        hit = false;
    }

    public override void ExitState()
    {
        Debug.Log("¾¾¹ß¼½½ºgg");
        StopAllCoroutines();
    }

    public override void UpdateState()
    {
        Debug.Log("¾¾¹ß¼½½º");
        if (!hit) BossMove();
    }

    void BossMove()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.W)) inputY = 1;
        if (Input.GetKey(KeyCode.S)) inputY = -1;

        skbRg.velocity = new Vector2(inputX, inputY) * moveSpeed;

        BossAnim(inputX);
    }

    void BossAnim(float input)
    {
        if (input < 0)
        {
            skbSp.sprite = leftSprite;
            skbAnim.enabled = false;
        }
        else if (input > 0)
        {
            skbSp.sprite = rightSprite;
            skbAnim.enabled = false;
        }
        else skbAnim.enabled = true;
    }
}
