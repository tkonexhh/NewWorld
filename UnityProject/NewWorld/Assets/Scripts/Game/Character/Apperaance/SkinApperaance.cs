/************************
	FileName:/Scripts/Game/Character/SkinApperaance.cs
	CreateAuthor:neo.xu
	CreateTime:7/2/2020 3:58:25 PM
	Tip:7/2/2020 3:58:25 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public class SkinApperaance : MonoBehaviour
    {
        [SerializeField] AppearanceSlot m_Slot;
        [SerializeField] private SkinnedMeshRenderer m_Renderer;

        private int m_CurID;

        private void Awake()
        {
            if (m_Renderer == null)
                m_Renderer = GetComponent<SkinnedMeshRenderer>();
        }

        public int SetSkin(Sex sex, int id)
        {
            if (m_CurID != id)
            {
                var newSkin = CharacterHolder.S.GetMeshBySlot(m_Slot, sex, id);
                m_Renderer.sharedMesh = newSkin.sharedMesh;

                m_CurID = id;
            }

            return m_CurID;
        }
    }

}