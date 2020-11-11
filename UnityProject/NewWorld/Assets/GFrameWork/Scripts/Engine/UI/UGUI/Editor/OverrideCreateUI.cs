using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

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

        [MenuItem("GameObject/UI/Text Mesh Pro")]
        static void CreatTextMeshPro()
        {
            CreateUI(TextMeshProUGUI);
        }

        [MenuItem("GameObject/UI/Button")]
        static void CreatButton()
        {
            CreateUI(Button);
        }


        [MenuItem("GameObject/UI/Custom/Progress/Progress_Horizontal")]
        static void CreatProgressHorizontal()
        {
            CreateUI(ProgressHorizontal);
        }

        [MenuItem("GameObject/UI/Custom/Progress/Progress_Circle")]
        static void CreatProgressCircle()
        {
            CreateUI(ProgressCircle);
        }

        [MenuItem("GameObject/UI/Custom/Toggle")]
        static void CreatToggle()
        {
            CreateUI(Toggle);
        }

        [MenuItem("GameObject/UI/Custom/LoopListView")]
        static void CreatLoopListView()
        {
            //CreateUI(Toggle);
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

        #region Create

        private static GameObject Image()
        {
            System.Action<GameObject> callback = (go) =>
            {
                Image image = go.GetComponent<Image>();
                HandleImage(image);
            };
            return CreateGO<GImage>("Img_", callback);
        }

        private static GameObject Text()
        {
            System.Action<GameObject> callback = (go) =>
            {
                Text text = go.GetComponent<Text>();
                HandleText(text);
            };
            return CreateGO<GText>("Txt_", callback);
        }

        private static GameObject TextMeshProUGUI()
        {
            System.Action<GameObject> callback = (go) =>
           {
               TextMeshProUGUI text = go.GetComponent<TextMeshProUGUI>();
               HandleTextMeshPro(text);
           };
            return CreateGO<TextMeshProUGUI>("TMP_", callback);
        }

        private static GameObject Button()
        {
            System.Action<GameObject> callback = (go) =>
            {
                var image = go.AddComponent<GImage>();
                var button = go.GetComponent<Button>();
                button.targetGraphic = image;

                GameObject textGo = new GameObject("Text", typeof(GText));
                textGo.transform.SetParent(go.transform);
                textGo.transform.localScale = Vector3.one;
                Text text = textGo.GetComponent<Text>();
                HandleText(text);
                RectTransform rectText = text.GetComponent<RectTransform>();
                rectText.SetAnchor(AnchorPresets.StretchAll, 0, 0);
                rectText.SetSize(button.GetComponent<RectTransform>().sizeDelta);
            };
            return CreateGO<GButton>("Btn_", callback);
        }

        private static GameObject ProgressHorizontal()
        {
            System.Action<GameObject> callback = (go) =>
            {
                var progress = go.GetComponent<GProgress>();
                var image = go.AddComponent<Image>();
                HandleImage(image);

                var rect = go.GetComponent<RectTransform>();
                rect.SetSize(new Vector2(300, 100));

                GameObject progressImgGo = new GameObject("ImgProgress", typeof(Image));
                RectTransform rectProgressImg = progressImgGo.GetComponent<RectTransform>();
                rectProgressImg.SetAnchor(AnchorPresets.StretchAll, 0, 0);
                rectProgressImg.SetSize(rect.sizeDelta);
                progressImgGo.transform.SetParent(go.transform);

                var progressImg = progressImgGo.GetComponent<Image>();
                HandleImage(progressImg);
                progressImg.type = UnityEngine.UI.Image.Type.Filled;
                progressImg.fillMethod = UnityEngine.UI.Image.FillMethod.Horizontal;

                GameObject progressTxtGo = new GameObject("TxtProgress", typeof(Text));
                RectTransform rectText = progressTxtGo.GetComponent<RectTransform>();
                rectText.SetAnchor(AnchorPresets.StretchAll, 0, 0);
                rectText.SetSize(rect.sizeDelta);
                progressTxtGo.transform.SetParent(go.transform);
                Text progressTxt = progressTxtGo.GetComponent<Text>();
                HandleText(progressTxt);

                ReflectionHelper.BindMenber(typeof(GProgress), "m_ImgProgress", progress, progressImg);
                ReflectionHelper.BindMenber(typeof(GProgress), "m_TxtProgress", progress, progressTxt);
                progress.SetProgress(0.6f);
            };
            return CreateGO<GProgress>("Progress_", callback);
        }

        private static GameObject ProgressCircle()
        {
            System.Action<GameObject> callback = (go) =>
            {
                var progress = go.GetComponent<GProgress>();
                var image = go.AddComponent<Image>();
                HandleImage(image);

                var rect = go.GetComponent<RectTransform>();
                rect.SetSize(new Vector2(200, 200));

                GameObject progressImgGo = new GameObject("ImgProgress", typeof(Image));
                RectTransform rectProgressImg = progressImgGo.GetComponent<RectTransform>();
                rectProgressImg.SetAnchor(AnchorPresets.StretchAll, 0, 0);
                rectProgressImg.SetSize(rect.sizeDelta);
                progressImgGo.transform.SetParent(go.transform);

                var progressImg = progressImgGo.GetComponent<Image>();
                HandleImage(progressImg);
                progressImg.type = UnityEngine.UI.Image.Type.Filled;
                progressImg.fillMethod = UnityEngine.UI.Image.FillMethod.Radial360;
                progressImg.fillOrigin = 2;
                progressImg.fillClockwise = false;

                GameObject progressTxtGo = new GameObject("TxtProgress", typeof(Text));
                RectTransform rectText = progressTxtGo.GetComponent<RectTransform>();
                rectText.SetAnchor(AnchorPresets.StretchAll, 0, 0);
                rectText.SetSize(rect.sizeDelta);
                progressTxtGo.transform.SetParent(go.transform);
                Text progressTxt = progressTxtGo.GetComponent<Text>();
                HandleText(progressTxt);

                ReflectionHelper.BindMenber(typeof(GProgress), "m_ImgProgress", progress, progressImg);
                ReflectionHelper.BindMenber(typeof(GProgress), "m_TxtProgress", progress, progressTxt);
                progress.SetProgress(0.6f);
            };
            return CreateGO<GProgress>("Progress_", callback);
        }

        private static GameObject Toggle()
        {
            System.Action<GameObject> callback = (go) =>
            {
                var toggle = go.GetComponent<Toggle>();
                var image = go.AddComponent<NoOverdrawImage>();
                toggle.targetGraphic = image;

                if (go.transform.parent != null)
                {
                    var toggleGroup = go.transform.parent.GetComponent<ToggleGroup>();
                    if (toggleGroup != null)
                    {
                        toggle.group = toggleGroup;
                    }
                }

                GameObject enableGo = new GameObject("Enable");
                enableGo.AddComponent<RectTransform>();
                enableGo.transform.SetParent(go.transform);
                GameObject disableGo = new GameObject("Disable");
                disableGo.AddComponent<RectTransform>();
                disableGo.transform.SetParent(go.transform);

                var toggleExtend = go.AddComponent<ToggleExtend>();
                ReflectionHelper.BindMenber(typeof(ToggleExtend), "m_Toggle", toggleExtend, toggle);
                ReflectionHelper.BindMenber(typeof(ToggleExtend), "m_EnableStateRoot", toggleExtend, enableGo);
                ReflectionHelper.BindMenber(typeof(ToggleExtend), "m_DisableStateRoot", toggleExtend, disableGo);
            };
            return CreateGO<Toggle>("Toggle_", callback);
        }

        private static GameObject LoopListView()
        {
            System.Action<GameObject> callback = (go) =>
            {

            };
            return CreateGO<USimpleListView>("ListView_", callback);
        }

        #endregion 

        #region HandleUI

        private static void HandleText(Text text)
        {
            text.raycastTarget = false;
            text.alignment = TextAnchor.MiddleCenter;
            text.text = "text";
            text.supportRichText = false;
            if (ProjectDefaultConfig.S != null)
            {
                text.font = ProjectDefaultConfig.defaultTextFont;
                text.color = ProjectDefaultConfig.defaultTextColor;
            }
        }

        private static void HandleTextMeshPro(TextMeshProUGUI tmp)
        {
            tmp.raycastTarget = false;
            tmp.richText = false;
            if (ProjectDefaultConfig.textMeshProConfig.font != null)
            {
                tmp.font = ProjectDefaultConfig.textMeshProConfig.font;
            }
            tmp.text = "Text";
            tmp.alignment = ProjectDefaultConfig.textMeshProConfig.textAlignment;
            tmp.color = ProjectDefaultConfig.textMeshProConfig.color;
            tmp.fontSize = ProjectDefaultConfig.textMeshProConfig.fontSize;
        }

        private static void HandleImage(Image image)
        {
            image.raycastTarget = false;
        }

        #endregion


        private static GameObject CreateGO<T>(string defaultName, System.Action<GameObject> callback)
        {
            GameObject go = new GameObject(defaultName, typeof(T));
            go.transform.SetParent(Selection.activeTransform);
            go.transform.SetLocalPos(Vector3.zero);
            go.transform.localScale = Vector3.one;
            Selection.activeGameObject = go;
            callback(go);
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
