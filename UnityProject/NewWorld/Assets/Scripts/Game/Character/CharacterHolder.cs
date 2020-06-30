/************************
	FileName:/Scripts/Game/Character/CharacterHolder.cs
	CreateAuthor:neo.xu
	CreateTime:6/30/2020 2:12:50 PM
	Tip:6/30/2020 2:12:50 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace GameWish.Game
{
    public enum Sex
    {
        Female,
        Male,
    }
    /// <summary>
    /// 用于获取装备Mesh等相关信息
    /// </summary>
    public class CharacterHolder : TMonoSingleton<CharacterHolder>
    {
        [SerializeField] private Transform m_TrsHair;
        [Header("Male")]
        [SerializeField] private Transform m_TrsHeadMale;

        [Header("Female")]
        [SerializeField] private Transform m_TrsHeadFemale;

        public SkinnedMeshRenderer GetHair(int id)
        {
            //id 0是光头
            var hair = m_TrsHair.GetChild(id);

            if (hair == null)
            {
                return null;
            }

            return hair.GetComponent<SkinnedMeshRenderer>();
        }

        public SkinnedMeshRenderer GetHead(Sex sex, int id)
        {
            Transform root = sex == Sex.Male ? m_TrsHeadMale : m_TrsHeadFemale;

            var head = root.GetChild(id);
            if (head == null)
            {
                return null;
            }

            return head.GetComponent<SkinnedMeshRenderer>();
        }
    }

}