#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyEditor))]
public class EnemyEditorUI : Editor
{

    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();

        var editor = (EnemyEditor)target;

        if(GUILayout.Button("CreateEnemy")) editor.CreateEnemy();

        if(GUILayout.Button("SaveEnemy")) editor.SaveEnemy();

        if(GUILayout.Button("LoadEnemy")) editor.LoadEnemy();

    }

}
#endif