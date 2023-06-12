using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointer : MonoBehaviour
{
    private Animator animator;
    private SavePointerManager manager;
    private GameObject player;
    bool isFlaging;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        manager = FindObjectOfType<SavePointerManager>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Physics2D.OverlapBox(transform.position, Vector2.one, 0, LayerMask.GetMask("Player")) && !isFlaging)
        {
            isFlaging = true;
            animator.SetTrigger("Flaging");
            manager.savePos = player.transform.position;
        }
        else if (!Physics2D.OverlapBox(transform.position, Vector2.one, 0, LayerMask.GetMask("Player")))
        {
            isFlaging = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector2.one);
    }
}
