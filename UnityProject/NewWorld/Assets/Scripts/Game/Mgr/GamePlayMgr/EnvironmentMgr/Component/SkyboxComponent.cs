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
        private Light m_MoonLight;//副光源
        private const float TOTALTIME = 24 * 3600;
        private bool m_IsNight = false;


        public override void Init(EnvironmentMgr mgr)
        {
            base.Init(mgr);
            m_MatSkyBox = RenderSettings.skybox;

            var mainLightGo = GameObject.FindGameObjectWithTag(TagDefine.TAG_MAINLIGHT);
            var moonLightGo = GameObject.FindGameObjectWithTag(TagDefine.TAG_MOONLIGHT);
            if (mainLightGo != null && moonLightGo != null)
            {
                m_MainLight = mainLightGo.GetComponent<Light>();
                m_MoonLight = moonLightGo.GetComponent<Light>();
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
            m_MainLight.transform.localRotation = Quaternion.Euler(Vector3.up * 360.0f * (time / TOTALTIME));
            m_MoonLight.transform.localRotation = Quaternion.Euler(Vector3.up * 360.0f * ((time + TOTALTIME / 2) / TOTALTIME));
            CheckDayNight();
            // Debug.LogError(m_MainLight.transform.localRotation.eulerAngles.y + "--" + m_MoonLight.transform.localRotation.eulerAngles.y);
        }

        private void CheckDayNight()
        {
            if (m_IsNight)
            {
                if (m_MoonLight.transform.localRotation.eulerAngles.y > 180)
                {
                    StartDay();
                }
            }
            else
            {
                if (m_MainLight.transform.localRotation.eulerAngles.y > 180)
                {
                    StartNight();
                }
            }
        }

        private void StartDay()
        {
            Debug.LogError("StartDay");
            m_IsNight = false;
            m_MainLight.shadows = LightShadows.Soft;
            m_MoonLight.shadows = LightShadows.None;
            SetGlobalShader(m_MainLight);
        }

        private void StartNight()
        {
            Debug.LogError("StartNight");
            m_IsNight = true;
            m_MainLight.shadows = LightShadows.None;
            m_MoonLight.shadows = LightShadows.Soft;
            SetGlobalShader(m_MoonLight);
        }

        private void SetGlobalShader(Light light)
        {
            Shader.SetGlobalVector("_MainLightPosition", light.transform.position);
            Shader.SetGlobalFloat("_MainLightAttenuation", light.range);
            Shader.SetGlobalColor("_MainLightColor", light.color);
        }
    }


    public class SkyBoxMaterial
    {

    }




}