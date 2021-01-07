/************************
	FileName:/Scripts/Game/Entity/Combat/Ability/AbilityExecution.cs
	CreateAuthor:neo.xu
	CreateTime:1/6/2021 4:45:18 PM
	Tip:1/6/2021 4:45:18 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    /// <summary>
    /// 能力执行体，能力执行体是实际创建执行能力表现，触发应用能力效果的地方
    /// 这里可以存一些表现执行相关的临时的状态数据
    /// </summary>
    public class AbilityExecution : Entity
    {
        public Ability ability { get; set; }



    }

}