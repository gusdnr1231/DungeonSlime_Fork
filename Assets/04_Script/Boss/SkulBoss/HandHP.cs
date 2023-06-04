using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHP : MonoBehaviour
{
    public int hp;

    private PlayerInput input;

    private void Awake()
    {
        input = FindObjectOfType<PlayerInput>();
    }


}
