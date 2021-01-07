using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GFrame
{
    /// <summary>
    /// 在Vector前面加上 就只会渲染 xy分量
    /// </summary>
    public class Vector3Drawer : MaterialPropertyDrawer
    {
        public override void OnGUI(Rect position, MaterialProperty prop, string label, MaterialEditor editor)
        {
            //	Needed since Unity 2019
            EditorGUIUtility.labelWidth = 0;

            Vector4 vec4value = prop.vectorValue;

            GUILayout.Space(-18);
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel(label);
            GUILayout.Space(-1);
            vec4value = EditorGUILayout.Vector3Field("", vec4value);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            // GUILayout.Space(2);
            if (EditorGUI.EndChangeCheck())
            {
                prop.vectorValue = vec4value;
            }
        }
    }
}