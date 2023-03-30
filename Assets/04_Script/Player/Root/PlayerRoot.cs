using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoot : MonoBehaviour
{

    protected PlayerInput input;
    protected Rigidbody2D rigid;
    protected GroundCol groundCol;

    protected virtual void Awake()
    {

        input = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody2D>();
        groundCol = FindObjectOfType<GroundCol>();

    }

}
