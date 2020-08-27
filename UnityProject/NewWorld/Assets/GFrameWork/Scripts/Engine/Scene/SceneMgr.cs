/************************
	FileName:/Scripts/Game/Scene/Mgr/SceneMgr.cs
	CreateAuthor:neo.xu
	CreateTime:8/25/2020 5:23:42 PM
	Tip:8/25/2020 5:23:42 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace GFrame
{
    [TMonoSingletonAttribute("[GFrame]/[Tools]/[SceneMgr]")]
    public class SceneMgr : TMonoSingleton<SceneMgr>
    {

        public override void OnSingletonInit()
        {

        }

        public void Init()
        {
            Log.i("#Init[SceneMgr]");
        }

        #region public func

        public void OpenScene<T>(T sceneID) where T : System.IConvertible
        {
            OpenScene(sceneID, null);
        }

        public void OpenScene<T>(T sceneID, System.Action callback, params object[] args) where T : System.IConvertible
        {
            SceneInfo panelInfo = LoadSceneInfo(sceneID.ToInt32(null));
            if (panelInfo == null)
            {
                return;
            }

            //先打开loading界面 然后在异步加载场景
            // OnOpenScene(() =>
            // {
            //     panelInfo.AddOpenCallback(callback);
            //     panelInfo.LoadSceneRes();
            // });

            panelInfo.AddOpenCallback(callback);
            panelInfo.LoadSceneRes();
        }
        #endregion

        #region private func
        private void OnOpenScene(System.Action callback)
        {
            UIMgr.S.OpenTopPanel(Game.Logic.UIID.LoadingPanel, (panel) =>
            {
                ((Game.Logic.LoadingPanel)panel).RegisterShowOverListener(() =>
                {
                    panel.CloseSelfPanel();
                    callback.Invoke();
                });
            });
        }

        private SceneInfo LoadSceneInfo(int sceneID)
        {
            SceneData data = SceneDataTable.Get(sceneID);
            if (data == null)
            {
                Log.e("#Not Find SceneData for SceneID:" + sceneID);
                return null;
            }

            //bool needAdd = true;
            SceneInfo sceneInfo = ObjectPool<SceneInfo>.S.Allocate();
            sceneInfo.Init(sceneID);

            return sceneInfo;
        }




        #endregion

    }

}