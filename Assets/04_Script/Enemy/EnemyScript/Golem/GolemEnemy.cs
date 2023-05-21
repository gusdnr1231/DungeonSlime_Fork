using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEnemy : EnemyRoot
{

    public override void AddEvent()
    {

        

    }

    public override void RemoveEvent()
    {

        StartCoroutine(CO());

    }

    private IEnumerator CO()
    {

        yield return null;
        GetComponent<DieEvent>().Die();

    }

}
