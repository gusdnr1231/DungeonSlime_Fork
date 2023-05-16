using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.AI.FSM;

public class TryChageChace : FAED_FSMTransition
{

    [SerializeField] private Vector2 boxRange;
    [SerializeField] private Vector2 offset;
    [SerializeField] private LayerMask playerLayer;

    private Transform player;

    protected override void Awake()
    {

        base.Awake();
        player = GameObject.Find("Player").transform;

    }

    public override bool ChackTransition()
    {

        bool value = Physics2D.OverlapBox(transform.position + (Vector3)offset, boxRange, 0, playerLayer);

        return value;

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        
        Color old = Gizmos.color;
        Gizmos.color = Color.white;
        //DrawCode
        Gizmos.DrawWireCube(transform.position + (Vector3)offset, boxRange);

        Gizmos.color = old;

    }

#endif

}
