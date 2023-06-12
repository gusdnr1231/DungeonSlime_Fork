using Interface;
using System.Collections;
using UnityEngine;
using FD.Dev;
using FD.Program.Managers;
using FD.Program.Core;

public class PlayerMove : PlayerMovementRoot, IMoveAbleObject
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float increseMoveSpeed;
    [SerializeField] private float maxMoveSpeed;

    private float addMoveSpeed;

    public bool moveAble { get; set; } = true;
    public bool isFlying;

    PlayerHide playerHide;
    private Vector3 particleOffset = new Vector3(0.35f, 0, 0);
    private float moveParticleCycleTime = 0.5f;
    private float currentTime = 0f;

    protected override void Awake()
    {

        base.Awake();

        playerHide = GetComponent<PlayerHide>();
        AddEvent();
    }

    private void Move(float value)
    {
        if (!moveAble) return;

        if(value == 0) addMoveSpeed = 1;
        if (addMoveSpeed <= maxMoveSpeed) addMoveSpeed += increseMoveSpeed/100f;

        rigid.velocity = new Vector2(value * moveSpeed * addMoveSpeed, rigid.velocity.y);
    }

    public void SetValMoveAble()
    {
        
        StopAllCoroutines();
        StartCoroutine(SetMoveAbleToVelCo());

    }

    public override void AddEvent()
    {
        
        input.OnMovementEvent += Move;
        input.OnMovementEvent += MoveParticle;

    }

    public override void RemoveEvent()
    {

        input.OnMovementEvent -= Move;

    }

    private void MoveParticle(float value)
    {
        if (!moveAble) return;
        if (groundCol.isGround == false) return;
        if (value == 0) return;
        if (playerHide.IsHide) return;

        Vector2 particlePos = transform.position + ((spriteRenderer.flipX) ? -particleOffset : particleOffset);

        currentTime += Time.deltaTime;
        if(currentTime >= moveParticleCycleTime)
        {
            currentTime = 0f;
            GameObject obj = FAED.Pop("MoveParticle", particlePos, Quaternion.identity);
            FAED.InvokeDelay(() =>
            {
                FAED.Push(obj);
            }, 0.5f);
        }
    }

    IEnumerator SetMoveAbleToVelCo()
    {

        moveAble = false;

        yield return new WaitUntil(() =>
        {

            return rigid.velocity == Vector2.zero;

        });

        moveAble = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFlying)
        {
            isFlying = false;
            moveAble = true;
        }
    }

}
