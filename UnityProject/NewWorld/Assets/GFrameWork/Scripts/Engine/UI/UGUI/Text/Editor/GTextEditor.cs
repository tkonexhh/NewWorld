using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GFrame.Editor
{

    [CustomEditor(typeof(GText))]
    public class GTextEditor : UnityEditor.UI.TextEditor
    {
        GText gText;

        protected override void OnEnable()
        {
            base.OnEnable();
            gText = (GText)target;
            gText.raycastTarget = false;
            gText.alignment = TextAnchor.MiddleCenter;
            gText.color = Color.black;
            gText.text = "text";
            gText.supportRichText = false;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();
            serializedObject.Update();

            EditorGUILayout.PropertyField(this.serializedObject.FindProperty("I18Nkey"));

            serializedObject.ApplyModifiedProperties();
            // serializedObject.Update();
        }
    }
}
