/************************
	FileName:/Scripts/Game/Mgr/GameResMgr/GameGlobalRes.cs
	CreateAuthor:neo.xu
	CreateTime:9/10/2020 7:20:36 PM
	Tip:9/10/2020 7:20:36 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    public class GameGlobalRes : MonoBehaviour
    {
        private CharacterHolder m_RoleHolder;

        public CharacterHolder roleHolder => m_RoleHolder;


        public void Reload()
        {
            AddressableResMgr.S.InstantiateAsync("ModularCharactersHolder", target =>
            {
                target.transform.SetParent(transform);
                target.transform.position = Vector3.one * 100;
                m_RoleHolder = target.GetComponent<CharacterHolder>();
            });
        }
    }

}