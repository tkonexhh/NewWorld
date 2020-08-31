/************************
	FileName:/GFrameWork/Tools/Postprocessor/ModelPreprocessorConfig.cs
	CreateAuthor:xuhonghua
	CreateTime:8/29/2020 9:57:58 PM
	Tip:8/29/2020 9:57:58 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame.AssetPreprocessor
{
    public class ModelPreprocessorConfig : BasePreprocessorConfig<ModelPreprocessorConfig>
    {
        [Header("Import Settings")]
        [SerializeField] private bool SortHierarchyByName = true;
        [SerializeField] private bool EnableReadWrite = false;


        [Header("Scene Settings")]
        [SerializeField] private bool ImportLights = false;
        [SerializeField] private bool ImportVisibility = false;
        [SerializeField] private bool ImportCameras = false;

        public bool sortHierarchyByName => S.SortHierarchyByName;
        public bool enableReadWrite => S.EnableReadWrite;

        public bool importLights => S.ImportLights;
        public bool importVisibility => S.ImportVisibility;
        public bool importCameras => S.ImportCameras;
    }

}