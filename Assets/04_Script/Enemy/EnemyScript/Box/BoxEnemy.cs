using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEnemy : EnemyRoot
{

    [SerializeField] private int maxUpCount = 4;

    private int upCount = 1;

    public override void AddEvent()
    {

        input.OnJumpEvent += BoxUpSkill;
        input.OnHideEvnet += BoxDownSkill;

    }

    public override void RemoveEvent() 
    {

        input.OnJumpEvent -= BoxUpSkill;
        input.OnHideEvnet -= BoxDownSkill;

    }

    private void BoxUpSkill()
    {

        if (upCount == maxUpCount) return;

        spriteRenderer.size += Vector2.up;
        enemyCollider.size += Vector2.up;
        enemyCollider.offset += new Vector2(0, 0.5f);
        upCount++;

    }

    private void BoxDownSkill()
    {

        if (upCount == 1) return;

        spriteRenderer.size -= Vector2.up;
        enemyCollider.size -= Vector2.up;
        enemyCollider.offset -= new Vector2(0, 0.5f);
        upCount--;

    }

}
