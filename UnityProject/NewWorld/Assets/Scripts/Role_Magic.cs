/************************
	FileName:/Scripts/Role_Magic.cs
	CreateAuthor:neo.xu
	CreateTime:6/5/2020 5:37:34 PM
	Tip:6/5/2020 5:37:34 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class Role_Magic : MonoBehaviour
    {
        [SerializeField] Animator m_Anim;

        void Update()
        {
            m_Anim.SetFloat("x", InputMgr.S.horizontalAxis);
            m_Anim.SetFloat("y", InputMgr.S.vertacalAxis);
        }
    }

}