using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemObject : MonoBehaviour
{

    [SerializeField] private string[] getAbleObjectTag;
    [SerializeField] private string getKey;

    private bool isFollowing;
    private Rigidbody2D target;
    private Rigidbody2D rigid;

    private void Awake()
    {
        
        rigid = GetComponent<Rigidbody2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (isFollowing) return;

        foreach(var item in getAbleObjectTag)
        {

            if (collision.CompareTag(item))
            {

                isFollowing = true;
                target = collision.transform.GetComponent<Rigidbody2D>();
                break;

            }

        }

    }

    private void Update()
    {

        if (!isFollowing) return;

        rigid.velocity = Vector3.Lerp(rigid.velocity, target.velocity, Time.deltaTime * 10);

    }

    public void SetTarget(Transform target)
    {

        this.target = target.GetComponent<Rigidbody2D>();

    }

}
