using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Game.Logic
{
    [CustomEditor(typeof(WeaponModel_TwoHandAxe))]
    public class WeaponModel_TwoHandAxeEditor : WeaponModelEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("绕点旋转"))
            {
                var model = (target as WeaponModel_TwoHandAxe);
                // model..Rotate(model.).AttachWeapon();
                // model.transform.RotateAround(model.rightHandPos.localPosition, Vector3.forward, 30);
            }
        }
    }


    public class WeaponModelEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("附着到装备点"))
            {
                (target as WeaponModel).AttachWeapon();
            }
        }
    }
}