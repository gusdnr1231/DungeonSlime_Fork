using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.AI.FSM;

public class TryChangeIdle : FAED_FSMTransition
{

    [SerializeField] private float maxRange;

    private Transform player;

    protected override void Awake()
    {

        base.Awake();
        player = GameObject.Find("Player").transform;

    }

    public override bool ChackTransition()
    {

        bool value = (Mathf.Abs(transform.position.x) - Mathf.Abs(player.position.x)) <= maxRange &&
            (Mathf.Abs(transform.position.y) - Mathf.Abs(player.position.y)) > 3;

        return value;

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {

        Color old = Gizmos.color;
        Gizmos.color = Color.red;
        //DrawCode
        Gizmos.DrawWireCube(transform.position, new Vector2(maxRange * 2, 1));

        Gizmos.color = old;

    }

#endif
}
