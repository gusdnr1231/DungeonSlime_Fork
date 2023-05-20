using Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skell : EnemyRoot
{

    [SerializeField] private EnemyRoot[] eventObjects;

    private DieEvent dieEvent;

    protected override void Awake()
    {

        dieEvent = GetComponent<DieEvent>();

    }

    public override void AddEvent()
    {

        StartCoroutine(AdCo());
        
        foreach(var item in eventObjects) 
        { 
            
            item.RemoveEvent();
        
        }

    }

    public override void RemoveEvent()
    {
    }

    private IEnumerator AdCo()
    {

        yield return null;
        dieEvent.Die();

    }

}
