/************************
	FileName:/Scripts/Game/Entity/Player/PlayerTestGUI.cs
	CreateAuthor:neo.xu
	CreateTime:11/4/2020 3:07:22 PM
	Tip:11/4/2020 3:07:22 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class PlayerTestGUI : MonoBehaviour
    {
        public bool showInputMoveVec = true;
        private Rigidbody m_Rigidbody;

        private void Awake()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
        }
        private void OnDrawGizmos()
        {
            if (showInputMoveVec)
            {
                Gizmos.color = Color.red;
                // Gizmos.DrawWireSphere(transform.position + 1.0f * new Vector3(GameInputMgr.S.moveInput.x, 0, GameInputMgr.S.moveInput.y), 0.1f);
                Gizmos.color = Color.green;
                // Gizmos.DrawWireSphere(transform.position + 2.0f * new Vector3(GameInputMgr.S.moveVec.x, 0, GameInputMgr.S.moveVec.y), 0.1f);
                Gizmos.color = Color.grey;

            }

            if (m_Rigidbody)
                Gizmos.DrawWireSphere(transform.position + m_Rigidbody.velocity, 0.1f);
        }
    }

}