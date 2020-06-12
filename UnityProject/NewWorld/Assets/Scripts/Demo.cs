/************************
	FileName:/Scripts/Demo.cs
	CreateAuthor:neo.xu
	CreateTime:6/12/2020 3:10:37 PM
	Tip:6/12/2020 3:10:37 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace GameWish.Game
{
    public class Demo : MonoBehaviour
    {
        // Start is called before the first frame update
        public List<GameObject> os = new List<GameObject>();
        void Start()
        {
            GameObject obj = new GameObject();
            GameObjectPoolMgr.S.AddPool("Test", obj, 10);
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                var go = GameObjectPoolMgr.S.GetObject("Test");
                go.transform.SetParent(transform);
                os.Add(go);
            }

            if (Input.GetMouseButtonDown(1))
            {
                for (int i = os.Count - 1; i >= 0; i--)
                {
                    GameObjectPoolMgr.S.Recycle(os[i]);
                    os.Remove(os[i]);
                }
            }
        }
    }

}