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


        public override void OnSingletonInit()
        {
            if (m_UIRoot == null)
            {
                UIRoot root = GameObject.FindObjectOfType<UIRoot>();
                if (root == null)
                {
                    root = LoadUIRoot();
                }

                m_UIRoot = root;
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



        public void OpenPanel<T>(T uiId, params object[] args)
        {

        }

        public void ClosePanelByUIID<T>(T uiID)
        {

        }
    }

}