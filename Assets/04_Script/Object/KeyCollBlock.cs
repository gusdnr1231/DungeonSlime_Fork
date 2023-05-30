using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollBlock : MonoBehaviour
{
    Key _key;
    KeyBlock _block;

    private void Start()
    {
        _block = transform.GetComponentInParent<KeyBlock>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.transform.Find("Key").TryGetComponent<Key>(out _key))
                return;
            if (_key.gotKey)
            {
                _block.Delete();
            }
        }
    }
}
