using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemDieEvt : DieEvent
{

    public override void Die()
    {

        base.Die();


    }

    public void SummonDieBlock()
    {

        if (GetComponent<DieSensor>().dieTag == "Water")
        {

            FAED.Pop("GolemBlock", transform.position, Quaternion.identity);

        }
        else
        {

            FAED.Pop("GolemBlock", transform.position, Quaternion.identity);

        }

        gameObject.SetActive(false);

    }

}
