using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject createObject;

    private void Awake()
    {
        Create();
    }

    public void Create()
    {
        Instantiate(createObject, transform.position, Quaternion.identity, transform);
    }

    void Update()
    {
        
    }
}
