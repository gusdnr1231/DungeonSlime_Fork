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

        if(GUILayout.Button("CreateDefaultMap")) editor.CreateDefaultMap();
        if(GUILayout.Button("SaveMap")) editor.SaveMap();
        if(GUILayout.Button("LoadMap")) editor.LoadMap();
        if(GUILayout.Button("Reset")) editor.ResetMap();

    }

}
#endif