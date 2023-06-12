using DG.Tweening;
using FD.AI.FSM;
using UnityEngine;
using FD.Dev;
using Cinemachine;

public class SkulBossIdle : FAED_FSMState
{
    [Header("GameObject")]
    [SerializeField] private GameObject head;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject dangerousBox;
    [SerializeField] private GameObject clearObject;
    [Header("Pos")]
    [SerializeField] private Transform leftPos;
    [SerializeField] private Transform rightPos;
    [SerializeField] private Transform headPos;
    [SerializeField] private Transform orgHeadpos;
    [SerializeField] private Transform orgLeftpos;
    [SerializeField] private Transform orgRightpos;
    [Header("Values")]
    [SerializeField] private BoxCollider2D onPlayer;
    [SerializeField] private float attackSpeed;
    [SerializeField] private Sprite attackSprite;
    [SerializeField] private Sprite normalSprite;

    private CinemachineBasicMultiChannelPerlin cbmcp;
    private Animator animator;
    private GameObject player;
    public int handCnt;
    public bool start;

    Color orignDangerousColor;

    void Awake()
    {
        cbmcp = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        orignDangerousColor = dangerousBox.GetComponent<SpriteRenderer>().color;
        dangerousBox.SetActive(false);
        player = FindObjectOfType<PlayerAnimator>().gameObject;
        animator = head.GetComponent<Animator>();

        FAED.InvokeDelay(() => { clearObject.SetActive(false); }, 0.1f);
    }

    private void Update()
    {
        if (start)
        {
            start = false;
            HeadMove();
        }
    }

    void HeadMove()
    {
        head.transform.DOMoveX(player.transform.position.x, 1).OnComplete(() =>
        {
            if (handCnt == 2)
            {
                if (Random.Range(0, 2) == 0)
                {
                    leftHand.GetComponent<SpriteRenderer>().sprite = attackSprite;
                    Attack(leftHand, leftPos.position, orgLeftpos.position, false); //왼손주먹공격
                }
                else
                    Bullet(leftHand, false); //왼손탄환공격
            }
            else if (handCnt == 1)
            {
                if (Random.Range(0, 2) == 0)
                {
                    rightHand.GetComponent<SpriteRenderer>().sprite = attackSprite;
                    Attack(rightHand, rightPos.position, orgRightpos.position, false); //오른손주먹공격
                }
                else
                    Bullet(rightHand, false); //오른손탄환공격
            }
            else if(handCnt == 0)
            {
                if (Random.Range(0, 2) == 0)
                    Attack(head, headPos.position, orgHeadpos.position, true); //머리공격
                else
                    Bullet(head, true); //머리탄환공격
            }
        });
    }

    void Attack(GameObject obj, Vector2 actPos, Vector2 backPos, bool boss)
    {
        obj.transform.DOMoveX(player.transform.position.x, 1);

        dangerousBox.GetComponent<SpriteRenderer>().color = orignDangerousColor;
        dangerousBox.transform.position = player.transform.position;
        dangerousBox.SetActive(true);
        dangerousBox.GetComponent<SpriteRenderer>().DOFade(0, 1).OnComplete(() => 
        {
            //보스 애니
            if (boss)
                animator.SetTrigger("Attack");

            obj.transform.DOMoveY(actPos.y, 0.4f).SetEase(Ease.InExpo).OnComplete(() => 
            {
                //흔들림
                cbmcp.m_AmplitudeGain = 2;
                FAED.InvokeDelay(() => { cbmcp.m_AmplitudeGain = 0; }, 0.5f);

                obj.GetComponent<HandHP>().possibleIn = true;
                FAED.InvokeDelay(() => 
                {
                    if (boss)
                        animator.SetTrigger("Normal");

                    obj.GetComponent<Collider2D>().enabled = false;
                    obj.GetComponent<HandHP>().possibleIn = false;
                    obj.transform.DOMove(backPos, 0.5f).SetEase(Ease.OutExpo).OnComplete(() => 
                    {
                        if (!boss)
                        {
                            leftHand.GetComponent<SpriteRenderer>().sprite = normalSprite;
                            rightHand.GetComponent<SpriteRenderer>().sprite = normalSprite;
                        }
                        obj.GetComponent<Collider2D>().enabled = true;
                        HeadMove();
                    });
                }, 3);
            });
        });
    }

    void Bullet(GameObject obj, bool boss)
    {
        GameObject mainBullet = Instantiate(bullet, obj.transform.position, Quaternion.identity);

        if (boss)
        {
            mainBullet.transform.localScale = new Vector2(2, 2);
        }
        else
        {
            GameObject sideBullet_1 = Instantiate(bullet, obj.transform.position, Quaternion.identity);
            GameObject sideBullet_2 = Instantiate(bullet, obj.transform.position, Quaternion.identity);

            sideBullet_1.GetComponent<SkulBossBullet>().angle = -1;
            sideBullet_2.GetComponent<SkulBossBullet>().angle = 1;
        }

        //흔들림
        cbmcp.m_AmplitudeGain = 2;
        FAED.InvokeDelay(() => { cbmcp.m_AmplitudeGain = 0; }, 0.5f);

        FAED.InvokeDelay(() =>
        {
            HeadMove();
        }, 2);
    }

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        if (handCnt <= -1)
        {
            //게임 종료
            //탈출구 열기
            DOTween.KillAll();
            clearObject.SetActive(true);
            head.SetActive(false);
        }
    }

    public override void ExitState()
    {
        StopAllCoroutines();
    }
}
