using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GFrame.Editor
{
    [CustomEditor(typeof(GButton))]
    public class GButtonEditor : UnityEditor.UI.ButtonEditor
    {
        GButton gImage;

        protected override void OnEnable()
        {
            base.OnEnable();
            gImage = (GButton)target;
            //gImage.raycastTarget = false;

        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();
            serializedObject.Update();

            //EditorGUILayout.PropertyField(this.serializedObject.FindProperty("clickEffect"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}
