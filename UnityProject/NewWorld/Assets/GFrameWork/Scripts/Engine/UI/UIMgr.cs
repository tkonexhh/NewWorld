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
        private EventSystem m_UIEventSystem = ObjectPool<EventSystem>.S.Allocate();
        private UIRoot m_UIRoot;
        private List<PanelInfo> m_ActivePanelInfoList = new List<PanelInfo>();
        private Dictionary<int, PanelInfo> m_ActivePanelInfoMap = new Dictionary<int, PanelInfo>();
        private List<PanelInfo> m_CachedPanelList = new List<PanelInfo>();
        private int m_NextPanelID = 0;

        #region setter getter
        public UIRoot uiRoot => m_UIRoot;
        public EventSystem uiEventSystem => m_UIEventSystem;

        private int nextPanelID
        {
            get
            {
                return ++m_NextPanelID;
            }
        }
        #endregion 

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


        #region  public Func
        public void OpenPanel<T>(T uiID, params object[] args) where T : System.IConvertible
        {
            OpenPanel(uiID, PanelType.Auto, null, args);
        }

        public void OpenPanel<T>(T uiID, System.Action<AbstractPanel> callback, params object[] args) where T : System.IConvertible
        {
            OpenPanel(uiID, PanelType.Auto, callback, args);
        }

        public void OpenPanel<T>(T uiID, PanelType type, System.Action<AbstractPanel> callback, params object[] args) where T : System.IConvertible
        {
            PanelInfo panelInfo = LoadPanelInfo(uiID.ToInt32(null));
            if (panelInfo == null)
            {
                return;
            }

            panelInfo.AddOpenCallback(callback);

            if (panelInfo.isReady)
            {
                Debug.LogError("panel is Ready");
            }
            else
            {
                panelInfo.LoadPanelRes();
            }

            panelInfo.SetActive(true);
            panelInfo.OpenPanel();
        }

        public void ClosePanelAsUIID<T>(T uiID) where T : System.IConvertible
        {
            int id = uiID.ToInt32(null);

            for (int i = m_ActivePanelInfoList.Count - 1; i >= 0; i--)
            {
                if (m_ActivePanelInfoList[i].uiID == id)
                {
                    ClosePanelInfo(m_ActivePanelInfoList[i]);
                }
            }
        }

        public void ClosePanel(AbstractPanel panel)
        {
            if (panel == null) return;

            PanelInfo panelInfo = FindPanelInfoByID(panel.panelID);

            if (panelInfo == null)
            {
                panelInfo = GetPanelFromCache(panel.panelID, false);
                if (panelInfo == null)
                {
                    Log.e("Not Find PanelInfo For Panel" + panel.name);
                    panel.OnPanelClose(true);
                    GameObject.Destroy(panel.gameObject);
                }
                return;
            }

            ClosePanelInfo(panelInfo);

        }

        #endregion


        public void InitPanel(GameObject go)
        {
            InitPanelGO(go, m_UIRoot.panelRoot);
        }

        #region private func
        private PanelInfo LoadPanelInfo(int uiID)
        {
            UIData data = UIDataTable.Get(uiID);
            if (data == null)
            {
                Log.e("#Not Find UIData for UIID:" + uiID);
                return null;
            }

            bool needAdd = true;
            PanelInfo panelInfo = GetPanelFromCache(uiID, true);
            if (panelInfo == null)//没有缓存
            {
                if (data.isSingleton)
                {
                    panelInfo = GetPanelFromActive(uiID);
                }

                if (panelInfo == null)
                {
                    panelInfo = ObjectPool<PanelInfo>.S.Allocate();
                    panelInfo.Init(uiID, nextPanelID);
                }
                else
                {
                    needAdd = false;
                }
            }

            if (needAdd)
            {
                AddPanelInfo(panelInfo);
            }

            return panelInfo;
        }

        private void AddPanelInfo(PanelInfo panelInfo)
        {
            if (panelInfo == null) return;

            if (m_ActivePanelInfoMap.ContainsKey(panelInfo.panelID))
            {
                Log.e("Already Add Panel to UIMgr");
                return;
            }

            m_ActivePanelInfoList.Add(panelInfo);
            m_ActivePanelInfoMap.Add(panelInfo.panelID, panelInfo);
        }

        private void RemovePanelInfo(PanelInfo panelInfo)
        {
            if (panelInfo == null) return;

            if (!m_ActivePanelInfoMap.ContainsKey(panelInfo.panelID))
            {
                Log.e("Already Remove Panel:" + panelInfo.uiID);
                return;
            }

            m_ActivePanelInfoMap.Remove(panelInfo.panelID);
            m_ActivePanelInfoList.Remove(panelInfo);
        }

        private PanelInfo GetPanelFromCache(int uiID, bool remove)
        {
            for (int i = m_CachedPanelList.Count - 1; i >= 0; --i)
            {
                if (m_CachedPanelList[i].uiID == uiID)
                {
                    PanelInfo panel = m_CachedPanelList[i];
                    if (remove)
                    {
                        m_CachedPanelList.RemoveAt(i);
                    }
                    return panel;
                }
            }
            return null;
        }

        private PanelInfo GetPanelFromActive(int uiID)
        {
            for (int i = m_ActivePanelInfoList.Count - 1; i >= 0; --i)
            {
                if (m_ActivePanelInfoList[i].uiID == uiID)
                {
                    PanelInfo panel = m_ActivePanelInfoList[i];
                    return panel;
                }
            }
            return null;
        }

        private PanelInfo FindPanelInfoByID(int uiID)
        {
            PanelInfo panelInfo = null;
            if (m_ActivePanelInfoMap.TryGetValue(uiID, out panelInfo))
            {
                return panelInfo;
            }

            return null;
        }

        private void ClosePanelInfo(PanelInfo panelInfo)
        {
            if (panelInfo == null) return;

            UIData data = UIDataTable.Get(panelInfo.uiID);
            bool destory = true;
            if (data != null && data.cacheCount > 0)
            {
                if (GetActiveAndCachedUICount(panelInfo.uiID) <= data.cacheCount)
                {
                    destory = false;
                }
            }

            RemovePanelInfo(panelInfo);

            if (destory)
            {
                panelInfo.ClosePanel(true);
            }
            else
            {
                m_CachedPanelList.Add(panelInfo);
                panelInfo.ClosePanel(false);
            }

            if (destory)
            {
                ObjectPool<PanelInfo>.S.Recycle(panelInfo);
            }
        }

        //Cache 和 Active的所有该UI 总数
        private int GetActiveAndCachedUICount(int uiID)
        {
            int result = 0;
            for (int i = m_CachedPanelList.Count - 1; i >= 0; --i)
            {
                if (m_CachedPanelList[i].uiID == uiID)
                {
                    ++result;
                }
            }

            for (int i = m_ActivePanelInfoList.Count - 1; i >= 0; --i)
            {
                if (m_ActivePanelInfoList[i].uiID == uiID)
                {
                    ++result;
                }
            }

            return result;
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