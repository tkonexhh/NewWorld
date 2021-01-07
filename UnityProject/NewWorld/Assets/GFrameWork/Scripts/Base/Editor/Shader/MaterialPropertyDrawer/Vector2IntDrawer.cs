using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GFrame
{
    /// <summary>
    /// 在Vector前面加上 就只会渲染 xy分量
    /// </summary>
    public class Vector2IntDrawer : MaterialPropertyDrawer
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
            Vector2Int vector2Int = new Vector2Int((int)vec4value.x, (int)vec4value.y);
            vector2Int = EditorGUILayout.Vector2IntField("", vector2Int);
            vec4value.x = vector2Int.x;
            vec4value.y = vector2Int.y;
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