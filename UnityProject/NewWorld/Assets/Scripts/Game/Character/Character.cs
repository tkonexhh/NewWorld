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
    public partial class Character : MonoBehaviour
    {
        [SerializeField] public CharacterAppearance appearance;
        [SerializeField] public CharacterStatus status;


        private void Awake()
        {
            if (appearance == null)
                appearance = GetComponent<CharacterAppearance>();
        }

        public void Equip(Equipment equipment)
        {
            //处理属性
            //处理外貌
            equipment.Equip(this);
        }

    }

}