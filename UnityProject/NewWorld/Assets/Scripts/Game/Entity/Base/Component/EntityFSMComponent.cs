/************************
	FileName:/Scripts/Game/Entity/Base/Component/EntityStateMachineComponent.cs
	CreateAuthor:neo.xu
	CreateTime:9/18/2020 5:28:28 PM
	Tip:9/18/2020 5:28:28 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace Game.Logic
{
    public class EntityFSMComponent : EntityComponennt
    {
        private FSMStateMachine<Entity> m_FSM;
        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            m_FSM = new FSMStateMachine<Entity>(ownner);
        }
    }

}