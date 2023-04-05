using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{

    [SerializeField] private List<string> jumpAbleTag = new List<string>();
    [SerializeField] private Vector2 posVector;
    [SerializeField] private float bouncePower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        foreach(var tag in jumpAbleTag)
        {

            if(collision.CompareTag(tag) && collision.TryGetComponent<PlayerMove>(out var pMove))
            {

                pMove.moveAble = false;
                pMove.GetComponent<Rigidbody2D>().velocity += posVector * bouncePower;
                pMove.SetValMoveAble();

            }
            else if (collision.CompareTag(tag) && collision.TryGetComponent<EnemyMovementHide>(out var eMove))
            {

                eMove.moveAble = false;
                eMove.GetComponent<Rigidbody2D>().velocity += posVector * bouncePower;
                eMove.SetValMoveAble();

            }

        }

    }

}
