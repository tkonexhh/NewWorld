/************************
	FileName:/Scripts/Game/SetupScene/SetupScene.cs
	CreateAuthor:neo.xu
	CreateTime:7/9/2020 8:27:07 PM
	Tip:7/9/2020 8:27:07 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace GameWish.Game
{
    public class CreateCharacterScene : MonoBehaviour
    {
        private void Start()
        {
            UIMgr.S.OpenPanel(UIID.CreateCharacterPanel);
        }
    }

}