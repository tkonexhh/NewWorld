/************************
	FileName:/Scripts/Player/PlayerMove.cs
	CreateAuthor:neo.xu
	CreateTime:6/8/2020 11:16:58 AM
	Tip:6/8/2020 11:16:58 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private InputSetting m_InputSetting;
        [SerializeField] private MovementSetting m_MovementSetting;
        [SerializeField] private AnimationSetting m_AnimationSetting;

        [SerializeField] private CharacterController m_CharacterController;
        [SerializeField] private Transform m_CameraTrans;
        [SerializeField] Animator m_Anim;

        [SerializeField] private GameObject m_ForceGO;
        public float tuenSmmothTime = 0.1f;
        float turnSmoothVelocity;
        private void Update()
        {
            m_InputSetting.GetInput();
            // float horizontal = m_InputSetting.Horizontal;
            // float vertical = m_InputSetting.Vertical;

            // Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

            // if (direction.magnitude > 0.1f)
            // {
            //     float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + m_CameraTrans.eulerAngles.y;
            //     float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, tuenSmmothTime);
            //     transform.rotation = Quaternion.Euler(0f, angle, 0);

            //     Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            //     m_CharacterController.SimpleMove(moveDirection.normalized * direction.magnitude * 2 * m_MovementSetting.moveSpeed * Time.deltaTime);
            // }

            SetUpAnim();

            if (Input.GetKeyDown(KeyCode.R))
            {
                m_ForceGO = m_ForceGO == null ? gameObject : null;
            }

        }

        private void FixedUpdate()
        {

        }

        private void SetUpAnim()
        {
            float horizontal = m_InputSetting.Horizontal;
            float vertical = m_InputSetting.Vertical;

            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

            if (m_ForceGO == null)
            {
                m_Anim.SetFloat("speed", direction.magnitude, m_AnimationSetting.dumpTime, Time.deltaTime);
            }
            else //专注目标模式
            {
                m_Anim.SetFloat("x", m_InputSetting.Horizontal, m_AnimationSetting.dumpTime, Time.deltaTime);
                m_Anim.SetFloat("y", m_InputSetting.Vertical, m_AnimationSetting.dumpTime, Time.deltaTime);
            }

            m_Anim.SetBool("Crouch", m_InputSetting.crouch);
            m_Anim.SetBool("Forcus", m_ForceGO != null);

        }

        void SquareToCircle(ref float x, ref float y)
        {
            x = Mathf.Sin(-x);
            y = Mathf.Cos(-y);
            //Debug.LogError("X:" + x + ">" + newx + "Y:" + y + ">" + newy);
        }
    }

}