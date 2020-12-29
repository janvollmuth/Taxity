using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DirectionDropdown))]
public class DirectionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DirectionDropdown direction = (DirectionDropdown)target;

        GUIContent arrayList = new GUIContent("Direction");
        direction.listIndex = EditorGUILayout.Popup(arrayList, direction.listIndex, direction.Direction.ToArray());
    }
}
