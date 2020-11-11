/************************
	FileName:/RoleAnimTestPanel.cs
	CreateAuthor:neo.xu
	CreateTime:11/11/2020 10:27:58 AM
	Tip:11/11/2020 10:27:58 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game.Logic
{
    public class RoleAnimTestPanel : MonoBehaviour
    {
        [SerializeField] private RoleWeaponTest m_Weapon;
        [SerializeField] private RoleMoveTest m_Move;

        private RoleAnimTest m_Role;
        public RoleAnimTest role => m_Role;
        public CharacterAppearance appearance => m_Role.appearanceComponent.appearance;
        public RoleMonoReference monoReference => m_Role.monoReference;
        public Animator animator => m_Role.animComponent.animator;

        private void Awake()
        {
            GameDataMgr.S.Init();
            m_Role = new RoleAnimTest();
            m_Role.onRoleCreated += (r) =>
            {
                r.transform.rotation = Quaternion.Euler(0, 150, 0);
                m_Weapon.Init(this);
                m_Move.Init(this);
            };

        }

    }

}