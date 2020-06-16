/************************
	FileName:/Scripts/Game/Mgr/Battle/BattleState/BattleState_Prepare.cs
	CreateAuthor:neo.xu
	CreateTime:6/15/2020 5:41:13 PM
	Tip:6/15/2020 5:41:13 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace GameWish.Game
{
    public class BattleState_Prepare : BattleState
    {
        public override void Enter(Battle entity)
        {
            base.Enter(entity);
            CreateBattle(Vector3.zero, entity);

            entity.stateMechine.SetState(BattleStateEnum.Start);
        }

        void CreateBattle(Vector3 poscenter, Battle entity)
        {

            float m_BlockWitdh = 1f;
            float m_Step = m_BlockWitdh * Mathf.Sqrt(3) / 2;

            int m_width = 10;
            int m_height = 10;

            for (int x = 0; x < m_width; x++)
            {
                for (int y = 0; y < m_height; y++)
                {
                    int posX = x;
                    int posY = y;
                    AddressableResMgr.S.InstantiateAsync("MapBlock", (obj) =>
                    {
                        if (posX % 2 == 0)
                        {
                            obj.transform.position = new Vector3(posX * (m_Step * 2), 0, posY * m_BlockWitdh * 2);
                        }
                        else
                        {
                            obj.transform.position = new Vector3(posX * (m_Step * 2), 0, (posY + 0.5f) * m_BlockWitdh * 2);
                        }
                        obj.transform.name = posX + "-" + posY;
                        var mapBlock = obj.GetComponent<BattleMapBlock>();
                        mapBlock.SetText(obj.transform.name);
                        entity.MapBlocks.Add(mapBlock);
                    });
                }
            }


        }
    }

}