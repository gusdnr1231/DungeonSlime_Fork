using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEnemy : EnemyRoot
{

    [SerializeField] private int maxUpCount = 4;

    private int upCount = 1;
    private GameObject bouncePos;

    protected override void Awake()
    {

        base.Awake();

        bouncePos = transform.Find("BouncePos").gameObject;

    }

    public override void AddEvent()
    {

        input.OnJumpEvent += BoxUpSkill;
        input.OnHideEvnet += BoxDownSkill;
        StopAllCoroutines();

    }

    public override void RemoveEvent() 
    {

        input.OnJumpEvent -= BoxUpSkill;
        input.OnHideEvnet -= BoxDownSkill;
        StartCoroutine(SmallCo());

    }



    private void BoxUpSkill()
    {

        if (upCount == maxUpCount) return;

        spriteRenderer.size += new Vector2(0, 1);
        enemyCollider.size += new Vector2(0, 1);
        bouncePos.transform.position += new Vector3(0, 1);
        enemyCollider.offset += new Vector2(0, 0.5f);
        upCount++;

    }

    private void BoxDownSkill()
    {

        if (upCount == 1) return;

        spriteRenderer.size -= new Vector2(0, 1);
        enemyCollider.size -= new Vector2(0, 1);
        bouncePos.transform.position -= new Vector3(0, 1);
        enemyCollider.offset -= new Vector2(0, 0.5f);
        upCount--;

    }

    private IEnumerator SmallCo()
    {

        yield return null;

        while (true) 
        {

            yield return new WaitForSeconds(1.5f);
            BoxDownSkill();
        
        }

    }

}
