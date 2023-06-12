using DG.Tweening;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHP : MonoBehaviour
{
    public float hp;
    float maxHp;
    public bool possibleIn, isIn, isNotDie;
    bool die;

    [Header("col")]
    [SerializeField] GameObject floorCol;
    [SerializeField] Transform floorColTrs;
    [Space(10)]
    [SerializeField] Transform outPos;
    [SerializeField] GameObject inArrow;
    [SerializeField] GameObject checkArrow;
    [SerializeField] GameObject part;
    [SerializeField] Transform pos;
    [SerializeField] Vector2 size;

    private SkulBossIdle bossIdle;
    private PlayerInput input;
    private GameObject player;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        bossIdle = FindObjectOfType<SkulBossIdle>();
        input = FindObjectOfType<PlayerInput>();
        player = FindObjectOfType<PlayerAnimator>().gameObject;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        input.OnHideEvnet += InHand;
        input.OnJumpEvent += AttackHP;

        maxHp = hp;
    }

    private void Update()
    {
        if (possibleIn && !isIn)
        {
            inArrow.SetActive(true);
        }
        else if(!possibleIn)
        {
            inArrow.SetActive(false);
            checkArrow.SetActive(false);
            if (isIn)
            {
                //플레이어 나오기
                isIn = false;
                player.transform.position = outPos.position;
                player.SetActive(true);
            }
        }

        floorCol.transform.position = floorColTrs.position;
    }

    void InHand()
    {
        if (Physics2D.OverlapBox(pos.position, size, 0, LayerMask.GetMask("Player")))
        {
            inArrow.SetActive(false);
            checkArrow.SetActive(true);
            isIn = true;
            //플레이어 들어가기
            player.SetActive(false);
        }
        else if (isIn)
        {
            //플레이어 나오기
            isIn = false;
            player.transform.position = outPos.position;
            player.SetActive(true);
        }
    }

    void AttackHP()
    {
        if (isIn)
        {
            hp--;

            spriteRenderer.color = Color.red;
            FAED.InvokeDelay(() => { spriteRenderer.color = Color.white; }, 0.05f);

            if (hp <= 0 && !die)
            {
                die = true; 
                isIn = false;

                //플레이어 나오기
                player.transform.position = outPos.position;
                player.SetActive(true);

                GameObject pa = Instantiate(part, transform.position, Quaternion.identity);
                pa.GetComponent<ParticleSystem>().Play();

                bossIdle.handCnt--;

                floorCol.SetActive(false);
                if(!isNotDie)
                    gameObject.SetActive(false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pos.position, size);
    }
}
