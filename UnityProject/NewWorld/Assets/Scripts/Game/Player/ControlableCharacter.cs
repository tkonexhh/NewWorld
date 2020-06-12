/************************
	FileName:/Scripts/Game/Player/ControlableCharacter.cs
	CreateAuthor:neo.xu
	CreateTime:6/12/2020 4:30:20 PM
	Tip:6/12/2020 4:30:20 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class ControlableCharacter : MonoBehaviour
    {
        public CharacterStatus status;
        private CharacterController m_CharCtrl;
        private bool m_Moving = false;
        private Vector3 movePos;

        private void Awake()
        {
            m_CharCtrl = GetComponent<CharacterController>();
        }


        public void SetMovePos(Vector3 pos)
        {
            movePos = pos;
            m_Moving = true;
        }


        private void FixedUpdate()
        {
            if (m_Moving)
            {
                if (Vector3.Distance(transform.position, movePos) > 0.5f)
                {
                    Vector3 dir = movePos - transform.position;
                    m_CharCtrl.Move(dir.normalized * status.moveSpeed);
                    m_Moving = true;
                }
                else
                {
                    m_Moving = false;
                }
            }

        }

    }

}