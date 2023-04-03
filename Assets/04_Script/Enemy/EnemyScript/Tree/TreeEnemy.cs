using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEnemy : EnemyRoot
{

    [SerializeField] private float growSpeed;
    [SerializeField] private float maxGrowSize;

    private bool isInput;
    private GameObject bouncePos;

    protected override void Awake()
    {

        base.Awake();

        bouncePos = transform.Find("BouncePos").gameObject;

    }

    private void Update()
    {

        if (isInput)
        {

            if (spriteRenderer.size.y >= maxGrowSize) return;

            spriteRenderer.size += Vector2.up * growSpeed * Time.deltaTime;
            enemyCollider.size += Vector2.up * growSpeed * Time.deltaTime;
            bouncePos.transform.position += (Vector3)Vector2.up * growSpeed * Time.deltaTime;
            enemyCollider.offset += (Vector2.up/ 2) * growSpeed * Time.deltaTime;

        }

    }

    private void TreeEvent(bool value)
    {

        isInput = value;

        if (value)
        {

            StopAllCoroutines();

        }
        else
        {

            StartCoroutine(UnGrowCo());

        }

    }

    public override void AddEvent()
    {

        input.OnJumpKeyPressEvent += TreeEvent;

    }

    public override void RemoveEvent() 
    {

        input.OnJumpKeyPressEvent -= TreeEvent;

    }

    IEnumerator UnGrowCo()
    {

        yield return new WaitForSeconds(3f);

        while(spriteRenderer.size.y > 1)
        {

            spriteRenderer.size -= Vector2.up * growSpeed * Time.deltaTime;
            enemyCollider.size -= Vector2.up * growSpeed * Time.deltaTime;
            enemyCollider.offset -= (Vector2.up / 2) * growSpeed * Time.deltaTime;
            bouncePos.transform.position -= (Vector3)Vector2.up * growSpeed * Time.deltaTime;
            yield return null;

        }

    }

}
