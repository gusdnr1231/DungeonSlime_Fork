using FD.AI.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayer : FAED_FSMTransition
{
    [SerializeField] private BoxCollider2D onPlayer;

    public override bool ChackTransition()
    {

        //bool d = Physics2D.OverlapBox(new Vector2(onPlayer.transform.position.x, onPlayer.transform.position.y + 2.4f), onPlayer.size, 0, LayerMask.GetMask("Player"));

        //if (d && Input.GetKeyDown(KeyCode.S))
        //{

        //    Debug.Log("¾¾¹ß");
        //    return true;

        //}

        return false;

    }
}
