using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;
using GFrame;

namespace Qarth
{
    public static class AnimationClipEditor
    {
        static int fileSumCount = 0;
        static int progress = 0;
        static string info = string.Empty;
        static string outputPath = Application.dataPath + "/Res/FolderMode/AnimationClips";
        static string[] formatFilter = new string[] { ".fbx" };
        static string[] loopFilter = new string[] { "walk", "idle", "run", "Walk", "Run", "Idle" };


        [MenuItem("Assets/AnimEditor/提取AnimationClips(Humanoid)")]
        static void GetHumanoidAnmationClips()
        {
            List<string> lstPaths = new List<string>();
            List<DirectoryInfo> lstDir = new List<DirectoryInfo>();

            if (Selection.assetGUIDs != null)
            {
                for (int i = 0; i < Selection.assetGUIDs.Length; i++)
                {
                    DirectoryInfo direction = new DirectoryInfo(AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[i]));
                    lstPaths.Add(AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[i]));
                    lstDir.Add(direction);
                }
            }
            if (lstDir == null)
            {
                Log.e("未选中文件夹！");
                return;
            }
            if (!Directory.Exists(outputPath))
            {
                Log.i("不存在文件夹,自动生成");
                Directory.CreateDirectory(outputPath);
            }
            List<FileInfo> lstFile = new List<FileInfo>();

            for (int i = 0; i < lstDir.Count; i++)
            {
                FileInfo[] files = lstDir[i].GetFiles("*", SearchOption.AllDirectories);
                if (files == null || files.Length == 0) return;

                for (int j = 0; j < files.Length; j++)
                {
                    if (!files[j].FullName.Contains(".meta"))
                    {
                        lstFile.Add(files[j]);
                    }
                }
                if (lstFile.Count == 0) return;

                for (int k = 0; k < lstFile.Count; k++)
                {
                    if (isAvailable(lstFile[k].FullName))
                    {
                        // ShowProgress(k / lstFile.Count, lstFile.Count, k, lstFile[k].Name);
                        string assetPath = PathHelper.ABSPath2AssetsPath(lstFile[k].FullName);
                        Debug.LogError(assetPath);
                        ModelImporter modelImporter = AssetImporter.GetAtPath(assetPath) as ModelImporter;
                        modelImporter.animationType = ModelImporterAnimationType.Human;
                        modelImporter.sourceAvatar = null;//AnimationEditorConfig.S.avatar;
                        modelImporter.SaveAndReimport();

                        AnimationClip newClip = new AnimationClip();
                        EditorUtility.CopySerialized(AssetDatabase.LoadAssetAtPath<AnimationClip>(assetPath), newClip);
                        newClip.name = RenameAnim(lstFile[k].Name);

                        AnimationClipSettings settings = AnimationUtility.GetAnimationClipSettings(newClip);
                        settings.loopTime = isLoopAnim(newClip.name);
                        settings.keepOriginalOrientation = true;
                        settings.keepOriginalPositionXZ = true;
                        settings.keepOriginalPositionY = true;
                        settings.loopBlendOrientation = true;
                        settings.loopBlendPositionXZ = true;
                        settings.loopBlendPositionY = true;
                        AnimationUtility.SetAnimationClipSettings(newClip, settings);

                        AssetDatabase.CreateAsset(newClip, "Assets/Res/FolderMode/AnimationClips/" + newClip.name + ".anim");
                        AssetDatabase.SaveAssets();
                    }
                }
                EditorUtility.ClearProgressBar();
                AssetDatabase.Refresh();

            }
        }

        // [MenuItem("Assets/AnimEditor/Build AnimConfig")]
        // public static void BuildAnimConfig()
        // {

        //     AnimationEditorConfig data = null;
        //     string folderPath = GetSelectedDirAssetsPath();
        //     string spriteDataPath = folderPath + "/AnimationEditorConfig.asset";

        //     data = AssetDatabase.LoadAssetAtPath<AnimationEditorConfig>(spriteDataPath);
        //     if (data == null)
        //     {
        //         data = ScriptableObject.CreateInstance<AnimationEditorConfig>();
        //         AssetDatabase.CreateAsset(data, spriteDataPath);
        //     }
        //     Log.i("Create AnimationEditor Config In Folder:" + spriteDataPath);
        //     EditorUtility.SetDirty(data);
        //     AssetDatabase.SaveAssets();
        // }

        public static string GetSelectedDirAssetsPath()
        {
            string path = string.Empty;

            foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
            {
                path = AssetDatabase.GetAssetPath(obj);
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    path = Path.GetDirectoryName(path);
                    break;
                }
            }

            return path;
        }

        private static bool isAvailable(string fileName)
        {
            for (int i = 0; i < formatFilter.Length; i++)
            {
                if (fileName.Contains(formatFilter[i]))
                {
                    return true;
                }
            }
            return false;
        }

        private static string GetAssetPath(string fullpath)
        {
            List<string> lstStr = StringHelper.String2ListString(fullpath, "\\");
            string path = "";
            bool start = false;
            if (lstStr != null && lstStr.Count > 0)
            {
                for (int i = 0; i < lstStr.Count; i++)
                {
                    if (lstStr[i] == "Assets")
                    {
                        start = true;
                    }
                    if (start)
                    {
                        if ((i == lstStr.Count - 1))
                        {
                            path += lstStr[i];
                        }
                        else
                        {
                            path += (lstStr[i] + "/");
                        }
                    }
                }
            }
            return path;
        }

        private static bool isLoopAnim(string animName)
        {
            for (int i = 0; i < loopFilter.Length; i++)
            {
                if (animName.Contains(loopFilter[i]))
                {
                    return true;
                }
            }
            return false;
        }

        private static string RenameAnim(string name)
        {
            string newName = name.Replace(" ", "_").Replace(".fbx", "");
            if (!newName.Contains("@"))
            {
                newName = "anim@" + newName;
            }
            return newName;
        }

        public static void ShowProgress(float val, int total, int cur, string picname)
        {
            EditorUtility.DisplayProgressBar(string.Format("Get Clip {0} ing...", picname), string.Format("wait({0}/{1}) ", cur, total), val);
        }

    }
}