/************************
	FileName:/Scripts/Game/UI/WorldUIPanel/WorldUIPanel.cs
	CreateAuthor:neo.xu
	CreateTime:11/9/2020 3:01:00 PM
	Tip:11/9/2020 3:01:00 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;
using DG.Tweening.Core.Easing;
using DG.Tweening;

namespace Game.Logic
{
    public class WorldUIPanel : AbstractPanel
    {
        public static WorldUIPanel S;

        [SerializeField] private DamageText m_DamageText;

        private Camera m_MainCamera;
        private Canvas m_Canvas;

        // private List<DamageText> m_DamageTexts;

        protected override void OnUIInit()
        {
            S = this;
            // m_DamageTexts = new List<DamageText>();
            m_Canvas = UIMgr.S.uiRoot.uiCanvas;
            InitPool();
        }

        private void InitPool()
        {
            GameObjectPoolMgr.S.AddPool("DamageText", m_DamageText.gameObject, 5);
        }


        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.O))
        //     {
        //         int random = Random.Range(0, 100);
        //         DamageTextEnum type = DamageTextEnum.Normal;
        //         if (random < 10)
        //         {
        //             type = DamageTextEnum.Crit;
        //         }
        //         ShowDamage(PlayerMgr.S.role.transform.position, new Vector3(Random.Range(-40, 40), Random.Range(-40, 40) + 60, 0), type, Random.Range(1, 200));
        //     }

        //     // for (int i = m_DamageTexts.Count - 1; i >= 0; i--)
        //     // {
        //     //     m_DamageTexts[i].Trick();
        //     // }
        // }
        public void ShowDamage(Vector3 worldPos, Vector3 offset, DamageTextEnum type, int num)
        {
            var damageTextGo = GameObjectPoolMgr.S.Allocate("DamageText");
            damageTextGo.transform.SetParent(transform);
            CustomExtensions.ScenePosition2UIPosition(GameCameraMgr.S.mainCamera, UIMgr.S.uiRoot.uiCamera, worldPos, damageTextGo.transform);
            damageTextGo.transform.localPosition += offset;
            var damageText = damageTextGo.GetComponent<DamageText>();
            damageText.ShowDamage(type, num, () =>
            {
                // m_DamageTexts.Remove(damageText);
                GameObjectPoolMgr.S.Recycle(damageTextGo);
            });

            // m_DamageTexts.Add(damageText);
        }

    }

}