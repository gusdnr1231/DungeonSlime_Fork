using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Dev;
using JetBrains.Annotations;

public class BreakBlock : MonoBehaviour
{
    [SerializeField] private Vector2 size, pos;
    private SpriteRenderer sp;
    private BoxCollider2D boxCol;
    //[SerializeField] private ParticleSystem particle;
    bool foot = false, isInvoked;

    private void Awake()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
        boxCol = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Physics2D.BoxCast(transform.position + (Vector3)pos, size, 0,
            Vector2.zero, 0, LayerMask.GetMask("Player", "Enemy")))
        {

            if (foot) return;
            foot = true;
            StartCoroutine(ColorA());
            FAED.InvokeDelay(() => {
                StartCoroutine(ReActive());
            }, 1f);

        }
    }

    IEnumerator ColorA()
    {
        for (int i = 0; i < 3; i++)
        {
            sp.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(0.15f);
            sp.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.15f);
        }
    }

    IEnumerator ReActive()
    {
        sp.enabled = false;
        boxCol.enabled = false;
        yield return new WaitForSeconds(3);
        sp.enabled = true;
        boxCol.enabled = true;
        foot = false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + (Vector3)pos, size);
    }
}
