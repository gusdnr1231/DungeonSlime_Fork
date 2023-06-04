using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BalloonEnemy : EnemyRoot
{
    [SerializeField] Sprite[] sprite;
    [SerializeField] GameObject particle;
    [SerializeField] float upSpeed;

    PlayerHide playerHide;
    Generator generator;
    GameObject jumpCheck;

    bool bomb;
    public int cnt = 0;
    int smallCnt = 0;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        playerHide = FindObjectOfType<PlayerHide>();
        jumpCheck = transform.GetChild(1).gameObject;
        generator = transform.parent.GetComponent<Generator>();
        StartCoroutine(DecreaseBalloon(2f));
    }

    IEnumerator DecreaseBalloon(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            if (cnt > 0)
            {
                cnt--;
                spriteRenderer.sprite = sprite[cnt];
            }
        }
    }

    private void Update()
    {
        ColorBalloon();
    }

    void ColorBalloon()
    {
        if (cnt == sprite.Length - 2)
        {
            rigid.velocity = Vector3.up * upSpeed;
            spriteRenderer.color = new Color(1, 0.6f, 0.6f, 1);
        }
        else if (cnt == sprite.Length - 1)
        {
            rigid.velocity = Vector3.up * upSpeed * 1.3f;
            spriteRenderer.color = new Color(1, 0.2f, 0.2f, 1);
        }
        else
        {
            rigid.velocity = Vector3.zero;
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }

    void Touch()
    {
        var jumpPos = transform.Find("BouncePos");

        if (Physics2D.OverlapBox(jumpPos.position + new Vector3(0, 1), new Vector2(1f, 1), 0, LayerMask.GetMask("Ground")) && cnt >= sprite.Length - 1)
        {
            return;
        }

        smallCnt++;
        if (smallCnt >= 4)
        {
            smallCnt = 0;
            cnt++;
        }

        if (cnt >= sprite.Length && !bomb)
        {
            bomb = true;
            jumpCheck.SetActive(false);
            playerHide.Bounce();

            GameObject part = Instantiate(particle, transform.position, Quaternion.identity);
            part.GetComponent<ParticleSystem>().Play();

            generator.Create();
            Destroy(gameObject);
        }
        else
        {
            spriteRenderer.sprite = sprite[cnt];
        }
    }

    public override void AddEvent()
    {

        jumpCheck.SetActive(true);
        input.OnJumpEvent += Touch;

    }

    public override void RemoveEvent()
    {

        jumpCheck.SetActive(false);
        input.OnJumpEvent -= Touch;

    }
}
