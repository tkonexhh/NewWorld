/************************
	FileName:/Scripts/Game/Mgr/PlayerMgr.cs
	CreateAuthor:neo.xu
	CreateTime:6/12/2020 4:37:13 PM
	Tip:6/12/2020 4:37:13 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace GameWish.Game
{
    public class PlayerMgr : TMonoSingleton<PlayerMgr>
    {

        [SerializeField] List<Role> m_Team;
        public List<Role> Team
        {
            get
            {
                return m_Team;
            }
        }

        public void DoMove(Vector3 pos)
        {
        }
    }

}