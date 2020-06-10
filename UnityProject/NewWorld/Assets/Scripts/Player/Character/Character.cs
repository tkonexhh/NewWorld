/************************
	FileName:/Scripts/Player/Character/Character.cs
	CreateAuthor:neo.xu
	CreateTime:6/10/2020 9:54:11 AM
	Tip:6/10/2020 9:54:11 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    [RequireComponent(typeof(CharacterAnim))]
    public class Character : MonoBehaviour
    {
        [HideInInspector] public CharacterAnim characterAnim;

        public Animator animator
        {
            get
            {
                return characterAnim.animator;
            }
        }

        private void Awake()
        {
            characterAnim = GetComponent<CharacterAnim>();
        }
    }

}