using Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{

    [SerializeField] private List<string> jumpAbleTag = new List<string>();
    [SerializeField] private Vector2 posVector, size, ofs;
    [SerializeField] private float bouncePower;
    [SerializeField] private bool ativeMoveable = true;
    [SerializeField] private AudioSource audioSource;

    private Animator animator;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();

    }

    public void Jump()
    {

        var v = Physics2D.OverlapBox(transform.position + (Vector3)ofs, size, 0);

        if (v == null) return;

        foreach (var tag in jumpAbleTag)
        {

            if (v.CompareTag(tag))
            {

                if (!ativeMoveable && v.TryGetComponent<IMoveAbleObject>(out var move))
                {

                    move.moveAble = false;
                    move.SetValMoveAble();

                }

                v.GetComponent<Rigidbody2D>().velocity += posVector * bouncePower;
                AudioManager.Instance.PlayAudio("PlayJumppad", audioSource);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        animator.SetTrigger("Jump");

    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {

        Gizmos.DrawWireCube(transform.position + (Vector3)ofs, size);

    }

#endif

}
