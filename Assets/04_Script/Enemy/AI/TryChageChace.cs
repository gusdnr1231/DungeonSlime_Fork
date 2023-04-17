using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.AI.FSM;

public class TryChageChace : FAED_FSMTransition
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

        bool value = Vector2.Distance(transform.position, player.position) <= maxRange;

        return value;

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        
        Color old = Gizmos.color;
        Gizmos.color = Color.white;
        //DrawCode
        Gizmos.DrawWireSphere(transform.position, maxRange);

        Gizmos.color = old;

    }

#endif

}
