using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace GFrame.Editor
{
    [CustomEditor(typeof(GImage))]
    public class GImageEditor : UnityEditor.UI.ImageEditor
    {
        GImage gImage;

        protected override void OnEnable()
        {
            base.OnEnable();
            gImage = (GImage)target;
            gImage.raycastTarget = false;

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
