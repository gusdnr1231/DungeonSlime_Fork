using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;

public class BreakBlock : MonoBehaviour
{
    [SerializeField] private Vector2 size, pos;
    //[SerializeField] private ParticleSystem particle;
    bool foot = false, isInvoked;

    private void Update()
    {
        if (Physics2D.BoxCast(transform.position + (Vector3)pos, size, 0,
            Vector2.zero, 0, LayerMask.GetMask("Player", "Enemy")))
        {

            if (foot) return;
            foot = true;
            FAED.InvokeDelay(() => {

                gameObject.SetActive(false);
            }, 3f);

        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + (Vector3)pos, size);
    }
}
