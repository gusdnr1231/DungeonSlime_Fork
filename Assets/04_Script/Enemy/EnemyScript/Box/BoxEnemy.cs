using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEnemy : EnemyRoot
{

    [SerializeField] private int maxUpCount = 4;

    private int upCount = 1;

    public override void AddEvent()
    {

        

    }

    public override void RemoveEvent() 
    {
        


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



    }

}
