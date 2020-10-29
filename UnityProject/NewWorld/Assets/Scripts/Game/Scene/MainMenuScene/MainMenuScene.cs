/************************
	FileName:/Scripts/Game/Scene/MainMenuScene/MainMenuScene.cs
	CreateAuthor:neo.xu
	CreateTime:8/27/2020 10:45:36 AM
	Tip:8/27/2020 10:45:36 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.Rendering.Universal;

namespace Game.Logic
{
    public class MainMenuScene : AbstractScene
    {
        [SerializeField] private Transform m_RoleRoot;
        protected override void OnSceneInit()
        {
            Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(UIMgr.S.uiRoot.uiCamera);
        }
        protected override void OnSceneEnter()
        {
            Debug.LogError("OnSceneEnter");
            Role role = new Role();
            role.onRoleCreated += (target) =>
            {
                target.transform.SetParent(m_RoleRoot);
                target.transform.localPosition = Vector3.zero;
                // m_RoleRoot.SetFocusRole(role);
            };
            // UIMgr.S.OpenPanel(UIID.MainMenuPanel);
        }

    }

}