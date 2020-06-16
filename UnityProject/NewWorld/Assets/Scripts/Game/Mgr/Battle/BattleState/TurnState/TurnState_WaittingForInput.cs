/************************
	FileName:/Scripts/Game/Mgr/Battle/BattleState/TurnState/TurnState_WaittingForInput.cs
	CreateAuthor:neo.xu
	CreateTime:6/16/2020 10:28:44 AM
	Tip:6/16/2020 10:28:44 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class TurnState_WaittingForInput : TurnState
    {
        public override void Enter(Battle entity)
        {
            base.Enter(entity);
        }

        public override void Exit(Battle entity)
        {
            base.Exit(entity);
        }

        public override void Execute(Battle entity, float dt)
        {
            base.Execute(entity, dt);

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                LayerMask mask = 1 << LayerDefine.Layer_Role;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
                {
                    Debug.LogError("----" + hit.transform.name);
                    //CreateMouseClickEffect(hit.point);

                    //GrassMgr.S.AddExplosion(hit.point, Random.Range(1.2f, 3.2f));
                }
            }
        }
    }

}