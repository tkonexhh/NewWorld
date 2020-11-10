using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace GFrame
{
    public class AnimationClipExportWindow : EditorWindow
    {
        [MenuItem("Tools/动画导出工具(Mixamo)")]
        public static void Open()
        {
            GetWindow<AnimationClipExportWindow>("动画导出工具(Mixamo)");
        }

        private enum AnimType
        {
            // None = 0,
            Legacy = 1,
            Generic = 2,
            Humanoid = 3,
        }

        private Avatar avatar;
        private string animresPath;
        private string outPutPath;
        private AnimType animType = AnimType.Humanoid;


        private void OnGUI()
        {
            GUILayout.BeginVertical();

            GUILayout.BeginHorizontal();
            GUILayout.Label("选择Avatar:");
            avatar = (Avatar)EditorGUILayout.ObjectField(avatar, typeof(Avatar), true);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            animType = (AnimType)EditorGUILayout.EnumPopup("导出动画类型:", animType);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("资源路径:");
            if (GUILayout.Button(string.IsNullOrEmpty(animresPath) ? "选择路径" : animresPath))
            {
                animresPath = EditorUtility.OpenFolderPanel("资源路径", Application.dataPath, "");
                if (string.IsNullOrEmpty(animresPath))
                {
                    Debug.Log("取消选择路径");
                }
                else
                {
                    animresPath = PathHelper.ABSPath2AssetsPath(animresPath) + "/";
                }
            }
            GUILayout.EndHorizontal();


            GUILayout.BeginHorizontal();
            GUILayout.Label("输出路径:");
            if (GUILayout.Button(string.IsNullOrEmpty(outPutPath) ? "选择路径" : outPutPath))
            {
                outPutPath = EditorUtility.OpenFolderPanel("输出路径", Application.dataPath, "");
                if (string.IsNullOrEmpty(outPutPath))
                {
                    Debug.Log("取消选择路径");
                }
                else
                {
                    outPutPath = PathHelper.ABSPath2AssetsPath(outPutPath) + "/";
                }
            }
            GUILayout.EndHorizontal();

            // GUILayout.BeginHorizontal();
            if (GUILayout.Button("导出动画片段"))
            {
                Export();
            }
            if (GUILayout.Button("重命名FBX动画片段"))
            {
                Rename();
            }
            if (GUILayout.Button("清除进度条()"))
            {
                EditorUtility.ClearProgressBar();
            }
            // GUILayout.EndHorizontal();

            GUILayout.EndVertical();
        }

        private void Rename()
        {
            List<string> lstPaths = new List<string>();
            List<DirectoryInfo> lstDir = new List<DirectoryInfo>();
            lstDir.Add(new DirectoryInfo(PathHelper.AssetsPath2ABSPath(animresPath)));

            if (lstDir == null)
            {
                Log.e("未选中文件夹！");
                return;
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
                        ShowProgress(k / lstFile.Count, lstFile.Count, k, lstFile[k].Name);
                        string assetPath = PathHelper.ABSPath2AssetsPath(lstFile[k].FullName);
                        ModelImporter modelImporter = AssetImporter.GetAtPath(assetPath) as ModelImporter;
                        switch (animType)
                        {
                            case AnimType.Legacy:
                                modelImporter.animationType = ModelImporterAnimationType.Legacy;
                                break;
                            case AnimType.Generic:
                                modelImporter.animationType = ModelImporterAnimationType.Generic;
                                modelImporter.autoGenerateAvatarMappingIfUnspecified = true;
                                break;
                            case AnimType.Humanoid:
                                modelImporter.animationType = ModelImporterAnimationType.Human;
                                // modelImporter.autoGenerateAvatarMappingIfUnspecified = true;
                                if (avatar == null)
                                    modelImporter.autoGenerateAvatarMappingIfUnspecified = true;
                                else
                                    modelImporter.sourceAvatar = avatar;
                                break;
                        }
                        var clips = modelImporter.defaultClipAnimations;
                        ModelImporterClipAnimation[] newClips = new ModelImporterClipAnimation[clips.Length];
                        for (int n = 0; n < clips.Length; n++)
                        {
                            ModelImporterClipAnimation clip = clips[i];
                            clips[i].name = RenameClip(lstFile[k].Name);
                            clips[i].loopTime = isLoopAnim(clips[i].name);
                            clips[i].keepOriginalOrientation = true;
                            clips[i].keepOriginalPositionXZ = true;
                            clips[i].keepOriginalPositionY = true;
                            newClips[n] = clip;
                        }
                        modelImporter.clipAnimations = newClips;
                        modelImporter.SaveAndReimport();
                    }
                }
            }

            EditorUtility.ClearProgressBar();
            AssetDatabase.Refresh();
        }

        private void Export()
        {
            if (avatar == null)
            {
                Debug.LogError("No Avatar");
                return;
            }

            if (string.IsNullOrEmpty(animresPath))
            {
                Debug.LogError("ResPath is null");
                return;
            }

            if (string.IsNullOrEmpty(outPutPath))
            {
                Debug.LogError("outPutPath is null");
                return;
            }
            GetAnmationClips(avatar, animresPath, outPutPath, animType);
        }


        static string[] formatFilter = new string[] { ".fbx", ".FBX" };
        static string[] loopFilter = new string[] { "walk", "idle", "run", "Walk", "Run", "Idle" };


        static void GetAnmationClips(Avatar avatar, string resPath, string outputPath, AnimType animType)
        {
            List<string> lstPaths = new List<string>();
            List<DirectoryInfo> lstDir = new List<DirectoryInfo>();
            lstDir.Add(new DirectoryInfo(PathHelper.AssetsPath2ABSPath(resPath)));

            if (lstDir == null)
            {
                Log.e("未选中文件夹！");
                return;
            }

            string absPath = PathHelper.ABSPath2AssetsPath(outputPath);
            if (!Directory.Exists(absPath))
            {
                Log.i("不存在文件夹,自动生成");
                Directory.CreateDirectory(absPath);
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
                        ShowProgress(k / lstFile.Count, lstFile.Count, k, lstFile[k].Name);
                        string assetPath = PathHelper.ABSPath2AssetsPath(lstFile[k].FullName);
                        ModelImporter modelImporter = AssetImporter.GetAtPath(assetPath) as ModelImporter;

                        switch (animType)
                        {
                            case AnimType.Legacy:
                                modelImporter.animationType = ModelImporterAnimationType.Legacy;
                                break;
                            case AnimType.Generic:
                                modelImporter.animationType = ModelImporterAnimationType.Generic;
                                modelImporter.autoGenerateAvatarMappingIfUnspecified = true;
                                break;
                            case AnimType.Humanoid:
                                modelImporter.animationType = ModelImporterAnimationType.Human;
                                // modelImporter.autoGenerateAvatarMappingIfUnspecified = true;
                                if (avatar == null)
                                    modelImporter.autoGenerateAvatarMappingIfUnspecified = true;
                                else
                                    modelImporter.sourceAvatar = avatar;
                                break;
                        }


                        modelImporter.SaveAndReimport();
                        AnimationClip newClip = new AnimationClip();
                        var obj = AssetDatabase.LoadAssetAtPath<AnimationClip>(assetPath);
                        EditorUtility.CopySerialized(AssetDatabase.LoadAssetAtPath<AnimationClip>(assetPath), newClip);
                        newClip.name = RenameAnim(lstFile[k].Name, animType);

                        AnimationClipSettings settings = AnimationUtility.GetAnimationClipSettings(newClip);
                        settings.loopTime = isLoopAnim(newClip.name);
                        settings.keepOriginalOrientation = true;
                        settings.keepOriginalPositionXZ = true;
                        settings.keepOriginalPositionY = true;
                        settings.loopBlendOrientation = true;
                        settings.loopBlendPositionXZ = true;
                        settings.loopBlendPositionY = true;
                        AnimationUtility.SetAnimationClipSettings(newClip, settings);
                        string newClipName = PathHelper.FileNameWithoutSuffix(newClip.name);
                        AssetDatabase.CreateAsset(newClip, outputPath + newClipName + ".anim");
                        AssetDatabase.SaveAssets();
                    }
                }
                EditorUtility.ClearProgressBar();
                AssetDatabase.Refresh();

            }
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

        private static string RenameAnim(string name, AnimType type)
        {
            string newName = name.Replace(" ", "_").Replace(".fbx", "").Replace(".", "_").Replace("__", "_");
            if (!newName.Contains("@"))
            {
                newName = "anim@" + newName;
            }
            switch (type)
            {
                case AnimType.Legacy:
                    newName = "legacy_" + newName;
                    break;
                case AnimType.Generic:
                    newName = "generic_" + newName;
                    break;
                case AnimType.Humanoid:
                    newName = "humanoid_" + newName;
                    break;
            }
            return newName;
        }

        private static string RenameClip(string name)
        {
            string newName = name.Replace(" ", "_").Replace(".fbx", "").Replace(".", "_").Replace("__", "_");
            return newName;
        }

        public static void ShowProgress(float val, int total, int cur, string picname)
        {
            EditorUtility.DisplayProgressBar(string.Format("Get Clip {0} ing...", picname), string.Format("wait({0}/{1}) ", cur, total), val);
        }
    }
}