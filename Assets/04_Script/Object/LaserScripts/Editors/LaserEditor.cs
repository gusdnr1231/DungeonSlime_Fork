#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LaserReflectBlock))]
public class LaserReflectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var editor = (LaserReflectBlock)target;

        GUILayout.Label("firstLaser");
        if (GUILayout.Button("SetTop")) editor.SetTop();
        if (GUILayout.Button("SetBottom")) editor.SetBottom();
        if (GUILayout.Button("SetLeft")) editor.SetLeft();
        if (GUILayout.Button("SetRight")) editor.SetRight();

        GUILayout.Label("secondLaser");
        if (GUILayout.Button("SetTop")) editor.SetReflectTop();
        if (GUILayout.Button("SetBottom")) editor.SetReflectBottom();
        if (GUILayout.Button("SetLeft")) editor.SetReflectLeft();
        if (GUILayout.Button("SetRight")) editor.SetReflectRight();

    }
}
[CustomEditor(typeof(LaserCheckBlock))]
public class LaserCheckEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var editor = (LaserBlock)target;

        if (GUILayout.Button("SetTop")) editor.SetTop();
        if (GUILayout.Button("SetBottom")) editor.SetBottom();
        if (GUILayout.Button("SetLeft")) editor.SetLeft();
        if (GUILayout.Button("SetRight")) editor.SetRight();

    }
}

[CustomEditor(typeof(ShotLaserBlock))]
public class ShotLaserEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var editor = (LaserBlock)target;

        if (GUILayout.Button("SetTop")) editor.SetTop();
        if (GUILayout.Button("SetBottom")) editor.SetBottom();
        if (GUILayout.Button("SetLeft")) editor.SetLeft();
        if (GUILayout.Button("SetRight")) editor.SetRight();
    }
}

[CustomEditor(typeof(LaserBlock))]
public class LaserEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var editor = (LaserBlock)target;

        if (GUILayout.Button("SetTop")) editor.SetTop();
        if (GUILayout.Button("SetBottom")) editor.SetBottom();
        if (GUILayout.Button("SetLeft")) editor.SetLeft();
        if (GUILayout.Button("SetRight")) editor.SetRight();
    }
}

#endif