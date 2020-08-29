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
    public class ModelPreprocessorConfig : BasePreprocessorConfig<AudioPreprocessorConfig>
    {
        [Header("Import Settings")]
        public bool EnableReadWrite = false;
    }

}