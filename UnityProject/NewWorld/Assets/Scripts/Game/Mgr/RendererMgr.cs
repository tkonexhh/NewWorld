/************************
	FileName:/Scripts/Game/Mgr/RenderMgr.cs
	CreateAuthor:neo.xu
	CreateTime:1/23/2021 11:46:28 AM
	Tip:1/23/2021 11:46:28 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using UnityEngine.Rendering.Universal;

namespace Game.Logic
{
    [TMonoSingletonAttribute("[Game]/[RendererMgr]")]
    public class RendererMgr : TMonoSingleton<RendererMgr>
    {
        public ForwardRendererData forwardRenderData;
        private List<ScriptableRendererFeature> _features;

        // private void Start()
        // {
        //     _features = forwardRenderData.rendererFeatures;
        // }

        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.Z))
        //     {
        //         _features[1].SetActive(false);
        //     }
        //     if (Input.GetKeyDown(KeyCode.X))
        //     {
        //         _features[1].SetActive(true);
        //     }
        // }

    }

}