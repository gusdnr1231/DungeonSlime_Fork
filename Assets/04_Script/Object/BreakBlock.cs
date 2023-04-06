using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;

public class BreakBlock : MonoBehaviour
{
    [SerializeField] private Vector2 size, pos;
    //[SerializeField] private ParticleSystem particle;
    bool foot = false;

    private void Update()
    {
        if (Physics2D.BoxCast(transform.position + (Vector3)pos, size, 0,
            Vector2.zero, 0, LayerMask.GetMask("Player", "Enemy")))
            foot = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (foot)
            FAED.InvokeDelay(() => {
                //particle.transform.position = transform.position;
                //particle.Play();
                gameObject.SetActive(false);
            }, 0.5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + (Vector3)pos, size);
    }
}
