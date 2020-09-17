/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleInputComponent.cs
	CreateAuthor:neo.xu
	CreateTime:9/17/2020 8:12:17 PM
	Tip:9/17/2020 8:12:17 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    //响应Input
    public class RoleInputComponent : RoleBaseComponent
    {
        public override void Init(Entity ownner)
        {
            base.Init(ownner);

            // GameInputMgr.S.mainAction.Move.
        }
    }

}