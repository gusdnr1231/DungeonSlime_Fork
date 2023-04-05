using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffBlockColliderChanger : MonoBehaviour
{

    private BoxCollider2D boxCollider;

    private void Awake()
    {
        
        boxCollider = GetComponent<BoxCollider2D>();

    }

    public void ChangeColSize(bool value)
    {

        boxCollider.size = value ? new Vector2(1, 0.11f) : new Vector2(1, 0.33f);
        boxCollider.offset = value ? new Vector2(0, -0.44f) : new Vector2(0, -0.33f);

    }

}
