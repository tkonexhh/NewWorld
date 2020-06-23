using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace GFrame.Editor
{
    public class OverrideCreateUI
    {
        /// <summary>
        /// 第一次创建UI元素时，没有canvas、EventSystem所有要生成，Canvas作为父节点
        /// 之后再空的位置上建UI元素会自动添加到Canvas下
        /// 在非UI树下的GameObject上新建UI元素也会 自动添加到Canvas下（默认在UI树下）
        /// 添加到指定的UI元素下
        /// </summary>
        [MenuItem("GameObject/UI/Image")]
        static void CreatImages()
        {
            var canvasObj = SecurityCheck();

            if (!Selection.activeTransform)      // 在根目录创建的， 自动移动到 Canvas下
            {
                // Debug.Log("没有选择对象");
                Image().transform.SetParent(canvasObj.transform);
            }
            else // (Selection.activeTransform)
            {
                if (!Selection.activeTransform.GetComponentInParent<Canvas>())    // 没有在UI树下
                {
                    Image().transform.SetParent(canvasObj.transform);
                }
                else
                {
                    Image();
                }
            }
        }

        [MenuItem("GameObject/UI/Text")]
        static void CreatTexts()
        {
            var canvasObj = SecurityCheck();

            if (!Selection.activeTransform)      // 在根目录创建的， 自动移动到 Canvas下
            {
                Text().transform.SetParent(canvasObj.transform);
            }
            else // (Selection.activeTransform)
            {
                if (!Selection.activeTransform.GetComponentInParent<Canvas>())    // 没有在UI树下
                {
                    Text().transform.SetParent(canvasObj.transform);
                }
                else
                {
                    Text();
                }
            }

        }

        private static GameObject Image()
        {
            GameObject go = new GameObject("Img_", typeof(GImage));

            go.GetComponent<GImage>().raycastTarget = false;

            go.transform.SetParent(Selection.activeTransform);
            go.transform.SetLocalPos(Vector3.zero);
            Selection.activeGameObject = go;
            return go;
        }

        private static GameObject Text()
        {
            GameObject go = new GameObject("Txt_", typeof(GText));
            Text text = go.GetComponent<Text>();

            text.raycastTarget = false;
            text.alignment = TextAnchor.MiddleCenter;
            text.color = Color.black;
            text.text = "text";
            text.supportRichText = false;

            go.transform.SetParent(Selection.activeTransform);
            go.transform.SetLocalPos(Vector3.zero);
            Selection.activeGameObject = go;
            return go;
        }


        // 如果第一次创建UI元素 可能没有 Canvas、EventSystem对象！
        private static GameObject SecurityCheck()
        {
            GameObject canvasGO;
            var cc = Object.FindObjectOfType<Canvas>();
            if (!cc)
            {
                canvasGO = new GameObject("Canvas", typeof(Canvas));
                canvasGO.AddComponent<CanvasScaler>();
                canvasGO.AddComponent<GraphicRaycaster>();
                Canvas canvas = canvasGO.GetComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            }
            else
            {
                canvasGO = cc.gameObject;
            }
            if (!Object.FindObjectOfType<UnityEngine.EventSystems.EventSystem>())
            {
                GameObject eventSystemGo = new GameObject("EventSystem", typeof(EventSystem));
                eventSystemGo.AddComponent<UnityEngine.EventSystems.EventSystem>();
                eventSystemGo.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
            }

            return canvasGO;
        }

    }
}
