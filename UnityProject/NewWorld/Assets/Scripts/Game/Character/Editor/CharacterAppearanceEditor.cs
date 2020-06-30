using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameWish.Game.Editor
{
    [CustomEditor(typeof(CharacterAppearance))]
    public class CharacterAppearanceEditor : UnityEditor.Editor
    {
        CharacterAppearance appearance;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Refesh Apperaance"))
            {
                ((CharacterAppearance)target).ApplyAppearance();
            }
        }
    }
}
