using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PlayerMovementRoot
{
    bool updating = false;
    public bool gotKey = false;
    Transform playerTrm;
    SpriteRenderer _spriteRender;
    BoxCollider2D _collider;

    protected override void Awake()
    {
        base.Awake();
        AddEvent();

        _spriteRender = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void SetFlip(float value)
    {
        _spriteRender.flipX = value switch
        {
            1 => false,
            -1 => true,
            _ => spriteRenderer.flipX
        };

        transform.position = value switch
        {
            1 => new Vector2(playerTrm.position.x - 0.8f, playerTrm.localPosition.y + 1),
            -1 => new Vector2(playerTrm.position.x + 0.8f, playerTrm.localPosition.y + 1),
            _ => transform.position
        };

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            this.transform.SetParent(collision.transform);
            _collider.enabled = false;
            updating = true;
            playerTrm = collision.GetComponent<Transform>();
            gotKey = true;
            input.OnMovementEvent += SetFlip;
        }
    }
}
