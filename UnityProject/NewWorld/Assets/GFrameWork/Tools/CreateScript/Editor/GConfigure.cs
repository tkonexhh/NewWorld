﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace GFrame
{
    public enum ScriptVersion
    {
        Mono,
        Panel,
        AnimPanel,
    }

    public class GConfigureDefine
    {
        public const string referencedefaultPath = "Scripts/Game/UIScripts/";
        public const string prefabdefaultPath = "Resources/UI/Panels/";

        public static string namespaceStr
        {
            get { return ProjectDefaultConfig.defaultNameSpace; }
        }
        public const int space = 20;


        public static GUILayoutOption toggleMaxWidth = GUILayout.Width(50);
        public static GUILayoutOption popupMaxWidth = GUILayout.Width(100);
        public static GUILayoutOption attriNameMaxWidth = GUILayout.Width(120);
        public static GUILayoutOption plusMaxWidth = GUILayout.Width(20);
    }

    public partial class GConfigure
    {
        private static ScriptVersion m_Version;
        public static string[] versionStr = new string[] { "Mono", "Panel", "AnimPanel" };
        public static Transform selectTransform;
        public static string referencePath;
        public static string prefabSavePath;

        public static string InfoPath
        {
            get
            {
                string plugPath = GetSelectObjectRootPath() + string.Format("/BindInfo/{0}_Info.asset", selectTransform.name);
                plugPath = plugPath.Remove(0, plugPath.IndexOf("Assets"));
                plugPath = plugPath.Replace("//", "/");
                return plugPath;
            }
        }

        public static string msgTitle = "温馨提示";
        public static string ok = "知道了";
        public static string noSelect = "没有选对象呢";
        public static string haveBeenCreated = "脚本已创建了，点击更新哦~";
        public static string notCreate = "你还没生成脚本呢";
        public static string hasMount = "已经挂载脚本了";
        public static string editorCompiling = "编辑器编译中...";
        public static string plugCreate = "没有使用插件生成对应的脚本呢";
        public static string copy = "复制到剪贴板啦！";
        public static string noMountScript = "还没挂载脚本～";
        public static string createPrefabSuccessTitle = "预制体创建成功";


        public static string variableFormat = "\t\t[SerializeField] private {0} m_{1};\n";
        public static string findFormat = "\t\t\tm_{0} = transform.Find(\"{1}\").GetComponent<{2}>();\n";
        public static string attributeVariableFormat = "\t\tprivate {0,-45} m_{1};\n";

        public static string attributeFormat = "\t\tpublic {0} {1} {{ get {{ return m_{1}; }} }}\n";
        public static string registerFormat = "\t\t\tm_{0}.{1}.AddListener({2});\n";
        public static string controllerEventFormat = "\t\tpublic Action{0} {1};\n";
        public static string functionFormat = "\t\tprivate void {0}({1})\n\t\t{{\n\t\t\tif( m_{2} != null ){3}({4});\n\t\t}}\n";
        public static string assetNotNull = "\t\t\tAssert.IsNotNull(m_{0});\n";
        public static string declareFormat = "\tpartial void {0}({1});\n";
        public static string funFormat = "\t\tprivate void {0}({1})\n\t\t{{\n\t\t{2}({3});\n\t\t}}\n";

        public static string uicodeOnAwake = "\t\tpartial void OnAwake()\n\t\t{\n\t\t}\n\n";
        public static string uicodeQarthPanel = "\t\tprotected override void OnUIInit()\n\t\t{\n\t\t}\n\n" +
                                                "\t\tprotected override void OnPanelOpen(params object[] args)\n\t\t{\n\t\t}\n\n" +
                                                "\t\tprotected override void OnOpen()\n\t\t{\n\t\t}\n\n" +
                                                "\t\tprotected override void OnClose()\n\t\t{\n\t\t}\n\n";

        public static string uicodeQarthAnimPanel = "\t\tprotected override void OnUIInit()\n\t\t{\n\t\t}\n\n" +
                                                    "\t\tprotected override void OnPanelOpen(params object[] args)\n\t\t{\n\t\t}\n\n" +
                                                    "\t\tprotected override void OnOpen()\n\t\t{\n\t\t}\n\n" +
                                                    "\t\tprotected override void OnPanelHideComplete()\n\t\t{\n\t\t}\n\n" +
                                                    "\t\tprotected override void OnClose()\n\t\t{\n\t\t}\n\n";

        public static string MainFileName { get { return GetMainFileName(); } }
        public static string UIBuildFileName { get { return GetFileName("BuildUI"); } }

        public static readonly string uiCode_Mono =
            "using UnityEngine;\n" +
            "using UnityEngine.UI;\n" +
            "using System;\n\n" +
            "namespace " + GConfigureDefine.namespaceStr + "\n{{\n" +
            "\tpublic partial class {0} : MonoBehaviour\n" +
            "\t{{\n{1}\n}}\n}" +
            "}";

        public static readonly string uiCode_Panel =
            "using UnityEngine;\n" +
            "using UnityEngine.UI;\n" +
            "using GFrame;\n" +
            "using System;\n\n" +
            "namespace " + GConfigureDefine.namespaceStr + "\n{{\n" +
            "\tpublic partial class {0} : AbstractPanel\n" +
            "\t{{\n{1}\n}}\n\t}" +
            "}";

        public static readonly string uiCode_AnimPanel =
            "using UnityEngine;\n" +
            "using UnityEngine.UI;\n" +
            "using GFrame;\n" +
            "using System;\n\n" +
            "namespace " + GConfigureDefine.namespaceStr + "\n{{\n" +
            "\tpublic partial class {0} : AbstractAnimPanel\n" +
            "\t{{\n{1}\n}}\n\t}" +
            "}";


        public static readonly string uiCode_BindUI =
            "using UnityEngine;\n" +
            "using UnityEngine.UI;\n" +
            "using UnityEngine.Assertions;\n" +
            "using System;\n\n" +
            "using GFrame;\n\n" +
            "namespace " + GConfigureDefine.namespaceStr + "\n{{\n" +
            "\tpublic partial class {0} \n" +
            "\t{{\n{1}\n}}\n}" +
            "}";

        public static readonly string uiClassCode =
            "{0}\n{1}\n{2}\n{3}\n" +
            "\t\tpartial void OnAwake();\n" +
            "\t\tprivate void Awake()\n\t\t{{\n" +
            "{4}\n{5}\n{6}\n{7}\n" +
            "\t\t\tbase.Awake();\n\n" +
            "\t\t\tOnAwake();\n\n" +
            "\t\t}}\n\n" +
            "{8}";

        public static readonly string uiClassCode_Mono =
            "{0}\n{1}\n{2}\n{3}\n" +
            "\t\tpartial void OnAwake();\n" +
            "\t\tprivate void Awake()\n\t\t{{\n" +
            "{4}\n{5}\n{6}\n{7}\n" +
            "\t\t\tOnAwake();\n\n" +
            "\t\t}}\n\n" +
            "{8}";


        public static ScriptVersion Version
        {
            get { return m_Version; }
            set
            {
                m_Version = value;
            }
        }

        public static string FilePath(string name)
        {
            var filePath = string.Format("{0}/{1}/{2}/{3}.cs", Application.dataPath, referencePath, GGlobalFun.GetString(Selection.activeTransform.name), name);
            if (!FileHelper.IsDirctoryName(filePath, true))
            {
                EditorUtility.DisplayDialog(msgTitle, "文件夹无法创建", "OK");
                Debug.LogException(new Exception("文件夹无法创建"));
            }
            return filePath;
        }

        public static string GetSelectObjectRootPath()
        {
            var path = string.Format("{0}/{1}/{2}/", Application.dataPath, referencePath, GGlobalFun.GetString(Selection.activeTransform.name));
            return path;
        }

        public static void Compiling()
        {
            EditorPrefs.SetBool("QConfigureSelectCompiling", true);
        }

        public static bool IsCompiling()
        {
            var value = EditorPrefs.GetBool("QConfigureSelectCompiling", false);
            EditorPrefs.SetBool("QConfigureSelectCompiling", false);
            return value;
        }

        private static string GetFileName(string suffix)
        {
            return string.Format("{0}/{1}_{0}", suffix, GGlobalFun.GetString(Selection.activeTransform.name));
        }

        private static string GetMainFileName()
        {
            return string.Format("{0}", GGlobalFun.GetString(Selection.activeTransform.name));
        }


        public static string GetShortTypeName(string type)
        {
            switch (type)
            {
                case "Image":
                    return "Img";
                case "Button":
                    return "Btn";
                case "Text":
                    return "Txt";
                case "Transform":
                    return "Trans";
                case "GameObject":
                    return "Obj";
                case "InputField":
                    return "Input";
                default:
                    return type;
            }
        }

        private static string[] s_FrontStr = new string[] { "Btn", "Button", "Image", "Img", "Transform", "Trans", "GameObject", "Obj", "Text", "Txt" };

        //优化名字
        public static string RemoveFrontTypeName(string name)
        {
            for (int i = 0; i < s_FrontStr.Length; i++)
            {
                if (name.StartsWith(s_FrontStr[i]))
                {
                    name = name.Remove(0, s_FrontStr[i].Length);
                    return name;
                }
                else if (name.EndsWith(s_FrontStr[i]))
                {
                    name = name.Remove(name.Length - s_FrontStr[i].Length, s_FrontStr[i].Length);
                    return name;
                }
            }


            return name;
        }
    }
}