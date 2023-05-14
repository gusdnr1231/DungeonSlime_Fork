using FD.AI.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayer : FAED_FSMTransition
{
    [SerializeField] private BoxCollider2D onPlayer;

    public override bool ChackTransition()
    {
        bool d = Physics2D.OverlapBox(new Vector2(onPlayer.transform.position.x, onPlayer.transform.position.y + 2.4f), onPlayer.size, 0, LayerMask.GetMask("Player"));
        Debug.Log(d);
        if (d && Input.GetKeyDown(KeyCode.S))
        {
            return true;
        }
        return false;
    }
}
