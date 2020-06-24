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
        static void CreatImage()
        {
            CreateUI(Image);
        }

        [MenuItem("GameObject/UI/Text")]
        static void CreatText()
        {
            CreateUI(Text);
        }

        [MenuItem("GameObject/UI/Button")]
        static void CreatButton()
        {
            CreateUI(Button);
        }

        private static void CreateUI(System.Func<GameObject> callback)
        {
            var canvasObj = SecurityCheck();

            if (!Selection.activeTransform)      // 在根目录创建的， 自动移动到 Canvas下
            {
                callback().transform.SetParent(canvasObj.transform);
            }
            else // (Selection.activeTransform)
            {
                if (!Selection.activeTransform.GetComponentInParent<Canvas>())    // 没有在UI树下
                {
                    callback().transform.SetParent(canvasObj.transform);
                }
                else
                {
                    callback();
                }
            }
        }

        private static GameObject Image()
        {
            System.Action<GameObject> callback = (go) =>
            {
                Image image = go.GetComponent<Image>();
                image.raycastTarget = false;
            };
            return CreateGO<GImage>("Img_", callback);
        }

        private static GameObject Text()
        {
            System.Action<GameObject> callback = (go) =>
            {
                Text text = go.GetComponent<Text>();
                text.font = ProjectDefaultConfig.defaultTextFont;
                text.raycastTarget = false;
                text.alignment = TextAnchor.MiddleCenter;
                text.color = ProjectDefaultConfig.defaultTextColor;
                text.text = "text";
                text.supportRichText = false;
            };
            return CreateGO<GText>("Txt_", callback);
        }

        private static GameObject Button()
        {
            System.Action<GameObject> callback = (go) =>
            {
                var button = go.GetComponent<Button>();
                var image = go.AddComponent<Image>();
                button.targetGraphic = image;


            };
            return CreateGO<Button>("Btn_", callback);
        }

        private static GameObject CreateGO<T>(string defaultName, System.Action<GameObject> callback)
        {
            GameObject go = new GameObject(defaultName, typeof(T));

            callback(go);

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
                var scaler = canvasGO.AddComponent<CanvasScaler>();
                //scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
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
