/************************
	FileName:/Scripts/Game/Mgr/GamePlayMgr.cs
	CreateAuthor:neo.xu
	CreateTime:6/12/2020 3:57:22 PM
	Tip:6/12/2020 3:57:22 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace GameWish.Game
{
    public class GamePlayMgr : TMonoSingleton<GamePlayMgr>
    {
        public override void OnSingletonInit()
        {
            //InitPools();

        }

        private void Start()
        {
            CreateBattle(Vector3.zero);
        }
        // void InitPools()
        // {

        //     GameObjectPoolMgr.S.AddPool();
        // }


        void CreateBattle(Vector3 poscenter)
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

                        obj.GetComponent<BattleMapBlock>().SetText(obj.transform.name);
                    });
                }
            }

        }
    }

}