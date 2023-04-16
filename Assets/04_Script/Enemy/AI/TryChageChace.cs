using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.AI.FSM;

public class TryChageChace : FAED_FSMTransition
{

    [SerializeField] private float maxRange;

    private Transform player;

    private void Awake()
    {

        player = GameObject.Find("Player").transform;

    }

    public override bool ChackTransition()
    {

        bool value = (Mathf.Abs(transform.position.x) - Mathf.Abs(player.position.x)) <= maxRange;

        return value;

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        
        Color old = Gizmos.color;
        Gizmos.color = Color.white;
        //DrawCode
        Gizmos.DrawWireCube(transform.position, new Vector2(maxRange * 2, 1));

        Gizmos.color = old;

    }

#endif

}
