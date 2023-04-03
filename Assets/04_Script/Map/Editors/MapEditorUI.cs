#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapEditor))]
public class MapEditorUI : Editor
{

    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();

        var editor = (MapEditor)target;

    }

}
#endif