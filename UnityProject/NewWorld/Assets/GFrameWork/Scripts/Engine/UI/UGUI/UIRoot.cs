/************************
	FileName:/GFrameWork/Scripts/Engine/UI/UGUI/UIRoot.cs
	CreateAuthor:neo.xu
	CreateTime:4/26/2020 11:57:13 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{

    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private Camera m_UICamera;
        [SerializeField] private Canvas m_UICanvas;

        public Camera uiCamera
        {
            get { return m_UICamera; }
        }

        public Canvas uiCanvas
        {
            get { return m_UICanvas; }
        }
    }

}