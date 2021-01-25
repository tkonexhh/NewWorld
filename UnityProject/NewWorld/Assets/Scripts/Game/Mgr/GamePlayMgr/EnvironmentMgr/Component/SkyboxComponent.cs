/************************
	FileName:/Scripts/Game/Mgr/EnvironmentMgr/Component/SkyboxComponent.cs
	CreateAuthor:neo.xu
	CreateTime:12/15/2020 6:51:40 PM
	Tip:12/15/2020 6:51:40 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class SkyboxComponent : EnvironmentComponent
    {
        private Material m_MatSkyBox;
        private Light m_MainLight;//主光源
        private Light m_BiMainLight;//副主光源
        private float totalTime = 24 * 3600;
        private Vector3 m_LightDir = Vector3.up;
        public override void Init(EnvironmentMgr mgr)
        {
            base.Init(mgr);
            m_MatSkyBox = RenderSettings.skybox;
            //获取到当前的天空盒材质
            //获得到场景中的主光源(太阳)
            var lightGo = GameObject.FindGameObjectWithTag(TagDefine.TAG_MAINLIGHT);
            if (lightGo != null)
            {
                m_MainLight = lightGo.GetComponent<Light>();
                SetLightRotation(environmentMgr.time);
            }
        }

        public override void Update(float dt)
        {
            if (m_MainLight != null)
            {
                SetLightRotation(environmentMgr.time);
            }
        }

        private void SetLightRotation(float time)
        {
            time -= 5 * 3600;
            m_MainLight.transform.localRotation = Quaternion.Euler(m_LightDir * 360.0f * (time / totalTime));
        }
    }


    public class SkyBoxMaterial
    {

    }




}