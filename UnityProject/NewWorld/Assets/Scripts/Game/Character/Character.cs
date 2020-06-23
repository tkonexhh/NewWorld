/************************
	FileName:/Scripts/Game/Character/Character.cs
	CreateAuthor:neo.xu
	CreateTime:6/16/2020 8:24:27 PM
	Tip:6/16/2020 8:24:27 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    [RequireComponent(typeof(CharacterAppearance))]
    public class Character : MonoBehaviour
    {
        [SerializeField] protected CharacterAppearance appearance;
        [SerializeField] protected CharacterStatus status;


        private void Awake()
        {
            if (appearance == null)
                appearance = GetComponent<CharacterAppearance>();
        }
    }

}