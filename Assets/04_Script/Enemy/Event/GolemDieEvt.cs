using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemDieEvt :DieEvent
{

    public override void Die()
    {

        base.Die();

        //¹° Á¶°Ç

        FAED.Pop("GolemBlock", transform.position - new Vector3(0, 0.75f), Quaternion.identity);
        gameObject.SetActive(false);

    }

}
