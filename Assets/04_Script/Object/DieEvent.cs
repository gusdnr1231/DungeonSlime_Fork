using FD.Dev;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEvent : MonoBehaviour
{

    [SerializeField] private bool isPlayer;

    public virtual event Action dieEvt;

    public virtual void Die()
    {

        if (isPlayer)
        {

            FAED.Push(gameObject);

        }
        else
        {

            Destroy(gameObject);

        }

        dieEvt?.Invoke();
        dieEvt = null;

    }

}
