using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkulBossBullet : MonoBehaviour
{
    public float angle;
    [SerializeField] private float bulletSpeed;

    private Rigidbody2D rb;
    private GameObject player;
    Vector2 pos;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerAnimator>().gameObject;

        pos = (player.transform.position - new Vector3(angle, 0)) - transform.position;
    }

    void Update()
    {
        rb.velocity = pos * bulletSpeed;
    }
}
