using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSize : MonoBehaviour
{
    public float size;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(size * 3.6f, size * 2, 0));
    }
}
