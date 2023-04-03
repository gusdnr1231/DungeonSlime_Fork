#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditor : MonoBehaviour
{
    
    private GameObject CreateObject(string name = "Obj")
    {

        return new GameObject(name);

    }

}
#endif