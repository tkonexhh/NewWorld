/************************
	FileName:/GFrameWork/Scripts/Engine/App/AppLoader.cs
	CreateAuthor:neo.xu
	CreateTime:4/26/2020 11:27:08 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class AppLoader : MonoBehaviour
    {
        private void Awake()
        {
            Log.i("#Init[{0}]", GameWish.Game.ApplicationMgr.S.GetType().Name);
            //Log.i("Init[{0}]", ApplicationMgr.S.GetType().Name);
        }

        private void Start()
        {
            Destroy(gameObject);
        }
    }

}