/************************
	FileName:/GFrameWork/Scripts/Engine/UI/UGUI/Base/UGUIEnum.cs
	CreateAuthor:neo.xu
	CreateTime:7/9/2020 5:11:14 PM
	Tip:7/9/2020 5:11:14 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    //面板管理的内部事件
    public enum ViewEvent
    {
        MIN = 0,
        Action_ClosePanel,
        Action_HidePanel,
        Action_ShowPanel,
        OnPanelOpen,
        OnPanelClose,
        OnParamUpdate,
        OnSortingLayerUpdate,
        DumpTest,
    }

    public enum PanelType : byte
    {
        Bottom,
        Auto,
        Top,  //顶层
    }

}