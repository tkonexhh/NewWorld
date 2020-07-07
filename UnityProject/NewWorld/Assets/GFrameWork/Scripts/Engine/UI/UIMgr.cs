/************************
	FileName:/GFrameWork/Scripts/Engine/UI/UIMgr.cs
	CreateAuthor:neo.xu
	CreateTime:6/16/2020 8:36:26 PM
	Tip:6/16/2020 8:36:26 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    [TMonoSingletonAttribute("[GFrame]/[Tools]/[UIMgr]")]
    public partial class UIMgr : TMonoSingleton<UIMgr>
    {
        private UIRoot m_UIRoot;
        private List<PanelData> m_ActivePanelInfoList = new List<PanelData>();
        private Dictionary<int, PanelData> m_ActivePanelInfoMap = new Dictionary<int, PanelData>();

        public UIRoot uiRoot
        {
            get { return m_UIRoot; }
        }

        public override void OnSingletonInit()
        {
            if (m_UIRoot == null)
            {
                UIRoot root = GameObject.FindObjectOfType<UIRoot>();
                if (root == null)
                {
                    root = LoadUIRoot();
                    root.gameObject.name = "[UIRoot]";
                }

                m_UIRoot = root;
                GameObject.DontDestroyOnLoad(m_UIRoot);
                if (m_UIRoot == null)
                {
                    Log.e("#Error:UIRoot Is Null.");
                }
            }
        }

        public void Init()
        {
            Log.i("#Init[UIMgr]");
        }

        private UIRoot LoadUIRoot()
        {
            Object prefab = Resources.Load(PathHelper.ResourcesPath2Path(ProjectPathConfig.uiRootPath), typeof(GameObject));
            if (prefab == null)
            {
                Log.e("#Error:Not Found UIRoot");
                return null;
            }
            GameObject uiRoot = GameObject.Instantiate(prefab as GameObject);
            return uiRoot.GetComponent<UIRoot>();
        }



        public void OpenPanel<T>(T uiId, params object[] args) where T : System.IConvertible
        {
            PanelData data = LoadPanelInfo(uiId.ToInt32(null));
            if (data == null)
            {
                return;
            }

            GameObject prefab = ResMgr.S.GetRes(data.fullPath).asset as GameObject;
            GameObject panelGo = GameObject.Instantiate(prefab);
            InitPanelGO(panelGo, uiRoot.uiCanvas.transform);
        }

        public void ClosePanelAsUIID<T>(T uiID) where T : System.IConvertible
        {
            int id = uiID.ToInt32(null);

            for (int i = m_ActivePanelInfoList.Count - 1; i >= 0; i--)
            {
                if (m_ActivePanelInfoList[i].uiID == id)
                {

                }
            }
        }

        public void ClosePanel(AbstractPanel panel)
        {
            if (panel == null) return;
            //PanelData panelData=FindPanelInfoByID(panel.)

        }


        #region 
        private PanelData LoadPanelInfo(int uiID)
        {
            UIData data = UIDataTable.Get(uiID);
            if (data == null)
            {
                Log.e("#Not Find UIData for UIID:" + uiID);
                return null;
            }
            return data as PanelData;
        }

        private PanelData FindPanelInfoByID(int uiID)
        {
            PanelData panelData = null;
            if (m_ActivePanelInfoMap.TryGetValue(uiID, out panelData))
            {
                return panelData;
            }

            return null;
        }


        private void InitPanelGO(GameObject go, Transform parent)
        {
            if (go == null)
            {
                return;
            }

            Vector3 anchorPos = Vector3.zero;
            Vector2 sizeDel = Vector2.zero;
            Vector3 scale = Vector3.one;
            Quaternion rotate = Quaternion.identity;

            RectTransform rtTr = go.GetComponent<RectTransform>();
            if (rtTr != null)
            {
                anchorPos = rtTr.anchoredPosition;
                sizeDel = rtTr.sizeDelta;
                scale = rtTr.localScale;
                rotate = rtTr.rotation;
            }

            rtTr.SetParent(parent, false);

            if (rtTr != null)
            {
                rtTr.anchoredPosition = anchorPos;
                rtTr.sizeDelta = sizeDel;
                rtTr.localScale = scale;
                rtTr.rotation = rotate;
            }
        }
        #endregion
    }

}