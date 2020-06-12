/************************
	FileName:/Scripts/Game/GameInput.cs
	CreateAuthor:neo.xu
	CreateTime:6/12/2020 2:09:57 PM
	Tip:6/12/2020 2:09:57 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace GameWish.Game
{
    public class GameInput : MonoBehaviour
    {


        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                LayerMask mask = 1 << LayerDefine.Layer_Ground;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
                {
                    Debug.LogError("----" + hit.transform.name);
                    CreateMouseClickEffect(hit.point);
                }
            }
        }


        private void CreateMouseClickEffect(Vector3 pos)
        {
            AddressableResMgr.S.InstantiateAsync("Cursor_Move", (target) =>
            {
                target.transform.position = pos;
                PlayerMgr.S.DoMove(pos);
            });
        }
    }

}