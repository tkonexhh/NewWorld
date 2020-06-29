/************************
	FileName:/GFrameWork/Scripts/Engine/UI/UGUI/CustomComponent/Progress/GProgress.cs
	CreateAuthor:neo.xu
	CreateTime:6/29/2020 5:53:07 PM
	Tip:6/29/2020 5:53:07 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GFrame
{
    /// <summary>
    /// 简易进度条
    /// </summary>
    public class GProgress : MonoBehaviour
    {
        [SerializeField] private Image m_ImgProgress;

        public void SetProgress(float progress)
        {
            m_ImgProgress.fillAmount = progress;
        }
    }

}