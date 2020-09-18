/************************
	FileName:/Scripts/Game/Entity/Role/Component/RoleInputComponent.cs
	CreateAuthor:neo.xu
	CreateTime:9/17/2020 8:12:17 PM
	Tip:9/17/2020 8:12:17 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Game.Logic
{
    //响应Input
    public class RoleInputComponent : RoleBaseComponent
    {
        private Vector2 m_InputMove = Vector2.zero;
        private Vector2 m_VecMove = Vector2.zero;
        private float m_VecSpeed = 3.0f;
        public override void Init(Entity ownner)
        {
            base.Init(ownner);

            GameInputMgr.S.mainAction.Move.performed += OnMovePerformed;
            GameInputMgr.S.mainAction.Move.canceled += OnMoveCancled;
        }

        private void OnMovePerformed(InputAction.CallbackContext callback)
        {
            m_InputMove = callback.ReadValue<Vector2>();
            Debug.LogError(m_InputMove);
            // role.animComponent.SetVelocity(m_InputMove);
        }

        private void OnMoveCancled(InputAction.CallbackContext callback)
        {
            m_InputMove = Vector2.zero;
            // role.animComponent.SetVelocity(m_InputMove);
        }

        public override void Update(float dt)
        {
            if (role.animComponent == null)
                return;
            m_VecMove = Vector2.Lerp(m_VecMove, m_InputMove, dt * m_VecSpeed);
            role.animComponent.SetVelocity(m_VecMove);
        }
    }

}