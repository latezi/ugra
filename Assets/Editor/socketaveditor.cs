using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.XR.Interaction.Toolkit;

[CustomEditor(typeof(avtagchecker))]
public class socketaveditor : XRSocketInteractorEditor
{
    private SerializedProperty targetuTag = null;

    protected override void OnEnable()
    {
        base.OnEnable();
        targetuTag = serializedObject.FindProperty("targetuTag");
    }

    protected override void DrawProperties()
    {
        base.DrawProperties();
        EditorGUILayout.PropertyField(targetuTag);
    }
}
