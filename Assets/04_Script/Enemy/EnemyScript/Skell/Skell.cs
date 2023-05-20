using Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skell : EnemyRoot
{

    private DieEvent dieEvent;

    protected override void Awake()
    {
        dieEvent = GetComponent<DieEvent>();
    }

    public override void AddEvent()
    {

        dieEvent.Die();

    }

    public override void RemoveEvent()
    {
    }
}
