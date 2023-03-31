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

    }

}
#endif