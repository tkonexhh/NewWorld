/************************
	FileName:/Scripts/Test/RoleTest/RoleTest.cs
	CreateAuthor:neo.xu
	CreateTime:9/18/2020 10:57:07 AM
	Tip:9/18/2020 10:57:07 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


namespace Game.Logic
{
    public class RoleTest : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera m_Camera;
        // Start is called before the first frame update
        void Start()
        {
            GamePlayMgr.S.Init();
            var role = EntityFactory.CreateRole();
            //role.transform.position = Vector3.zero;

            m_Camera.Follow = role.transform;
            m_Camera.LookAt = role.transform;
        }


    }

}