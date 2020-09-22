using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using GFrame;

[CustomEditor(typeof(MTMeshCreator))]
public class MTMeshCreatorEditor : Editor
{
    //TODO 摸索下来比较合适的配置
    //因为是Lowpoly风格的游戏 所以地形并不需要那么高的面数 
    //LOD1 Subdivision 5 Slope 20
    //LOD2 Subdivision 4 Slope 20
    //LOD3 Subdivision 3 Slope 20
    //LOD4 Subdivision 2 Slope 20

    private void DrawSetting(int idx, MTMeshLODSetting setting)
    {
        bool bFold = EditorGUILayout.Foldout(setting.bEditorUIFoldout, string.Format("LOD {0}", idx));
        if (!bFold)
        {
            int subdivision = EditorGUILayout.IntField("Subdivision(1 ~ 7)", setting.Subdivision);
            if (setting.Subdivision != subdivision)
            {
                setting.Subdivision = Mathf.Clamp(subdivision, 1, 7);
            }
            float slopeErr = EditorGUILayout.FloatField("Slope Tolerance(Max 45)", setting.SlopeAngleError);
            if (setting.SlopeAngleError != slopeErr)
            {
                setting.SlopeAngleError = Mathf.Clamp(slopeErr, 0, 45);
            }
        }
        if (setting.bEditorUIFoldout != bFold)
        {
            setting.bEditorUIFoldout = bFold;
        }
    }


    public override void OnInspectorGUI()
    {
        MTMeshCreator comp = (MTMeshCreator)target;
        // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
        serializedObject.Update();
        base.OnInspectorGUI();
        int lodCount = comp.LOD.Length;
        int lod = EditorGUILayout.IntField("LOD (1 ~ 4)", lodCount);
        if (lod != lodCount)
        {
            lodCount = Mathf.Clamp(lod, 1, 4);
            MTMeshLODSetting[] old = comp.LOD;
            comp.LOD = new MTMeshLODSetting[lodCount];
            for (int i = 0; i < lodCount; ++i)
            {
                comp.LOD[i] = new MTMeshLODSetting();
                if (i < old.Length)
                {
                    comp.LOD[i].Subdivision = old[i].Subdivision;
                    comp.LOD[i].SlopeAngleError = old[i].SlopeAngleError;
                }
            }
        }
        for (int i = 0; i < lodCount; ++i)
        {
            DrawSetting(i, comp.LOD[i]);
        }
        if (GUILayout.Button("CreateData"))
        {
            if (comp.DataName == "")
            {
                Debug.LogError("data should have a name");
                return;
            }
            comp.EditorCreateDataBegin();
            for (int i = 0; i < int.MaxValue; ++i)
            {
                comp.EditorCreateDataUpdate();
                EditorUtility.DisplayProgressBar("creating data", "scaning volumn", comp.EditorCreateDataProgress);
                if (comp.IsEditorCreateDataDone)
                    break;
            }
            comp.EditorCreateDataEnd();
            comp.EditorTessBegin();
            for (int i = 0; i < int.MaxValue; ++i)
            {
                comp.EditorTessUpdate();
                EditorUtility.DisplayProgressBar("creating data", "tessellation", comp.EditorTessProgress);
                if (comp.IsEditorTessDone)
                    break;
            }
            EditorUtility.DisplayProgressBar("saving data", "processing", 1f);
            comp.EditorTessEnd();
            EditorUtility.ClearProgressBar();
            AssetDatabase.Refresh();
        }
        if (GUILayout.Button("CreatePreview"))
        {
            comp.EditorCreatePreview();
        }
        if (GUILayout.Button("ClearPreview"))
        {
            comp.EditorClearPreview();
        }


        GUILayout.BeginHorizontal();
        for (int i = 0; i < comp.LOD.Length; i++)
        {
            int index = i;
            if (GUILayout.Button("LOD" + i))
            {
                var childs = comp.transform.GetChildTrsList();
                for (int j = 0; j < childs.Count; j++)
                {
                    childs[j].gameObject.SetActive(j == index);
                }

                // /comp.EditorClearPreview();
            }
        }
        GUILayout.EndHorizontal();
        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties();
    }
}
