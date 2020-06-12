/************************
	FileName:/Scripts/Game/GameInput.cs
	CreateAuthor:neo.xu
	CreateTime:6/12/2020 2:09:57 PM
	Tip:6/12/2020 2:09:57 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.LogError("----" + hit.transform.name);
                    CreateMouseClickEffect(hit.point);
                }
            }
        }


        private void CreateMouseClickEffect(Vector3 pos)
        {

        }
    }

}