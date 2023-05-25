using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemObject : MonoBehaviour
{

    [SerializeField] private string[] getAbleObjectTag;
    [SerializeField] private string getKey;

    private bool isFollowing;
    private Transform target;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (isFollowing) return;

        foreach(var item in getAbleObjectTag)
        {

            if (collision.CompareTag(item))
            {

                isFollowing = true;
                target = collision.transform;
                break;

            }

        }

    }

    private void Update()
    {

        if (!isFollowing) return;

        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime);

    }

    public void SetTarget(Transform target)
    {

        this.target = target;

    }

    public void TrySave()
    {

        if(!isFollowing) return;
        Managers.Gem.SetClear(getKey);

    }

}
