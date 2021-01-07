/************************
	FileName:/Scripts/Game/Entity/Combat/Ability/Ability.cs
	CreateAuthor:neo.xu
	CreateTime:1/6/2021 4:39:23 PM
	Tip:1/6/2021 4:39:23 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    /// <summary>
    /// 我们把某类功能称为能力，这类功能可以通过应用效果、修改数据来影响角色的属性或状态。这类功能有技能、被动、buff、debuff等。
	/// 储存能力数据
    /// </summary>
    public class Ability : Entity
    {
        public Entity owner { get; set; }


        /// <summary>
        /// 激活能力
        /// </summary>
        public virtual void Activate()
        {

        }

        /// <summary>
        /// 能力结束
        /// </summary>
        public virtual void End()
        {

        }

    }

}