using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{

    [SerializeField] private List<string> jumpAbleTag = new List<string>();
    [SerializeField] private Vector2 posVector;
    [SerializeField] private float bouncePower;
    [SerializeField] private bool ativeMoveable = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        foreach(var tag in jumpAbleTag)
        {

            if(collision.CompareTag(tag) && collision.TryGetComponent<PlayerMove>(out var pMove))
            {

                if (!ativeMoveable)
                {

                    pMove.moveAble = false;
                    pMove.SetValMoveAble();

                }
                pMove.GetComponent<Rigidbody2D>().velocity += posVector * bouncePower;

            }
            else if (collision.CompareTag(tag) && collision.TryGetComponent<EnemyMovementHide>(out var eMove))
            {

                if (!ativeMoveable)
                {

                    eMove.moveAble = false;
                    eMove.SetValMoveAble();

                }
                eMove.GetComponent<Rigidbody2D>().velocity += posVector * bouncePower;

            }

        }

    }

}
