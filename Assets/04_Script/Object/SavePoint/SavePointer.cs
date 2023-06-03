using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointer : MonoBehaviour
{
    private SavePointerManager manager;
    private GameObject player;

    private void Awake()
    {
        manager = FindObjectOfType<SavePointerManager>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Physics2D.OverlapBox(transform.position, Vector2.one, 0, LayerMask.GetMask("Player")))
        {
            manager.savePos = player.transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector2.one);
    }
}
