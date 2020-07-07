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
        private bool m_IsHide;
        private CharacterAppearance m_Character;

        private void Awake()
        {
            if (m_Renderer == null)
                m_Renderer = GetComponent<SkinnedMeshRenderer>();
        }

        public void Init(CharacterAppearance character)
        {
            m_Character = character;
        }

        public int SetSkin(Sex sex, int id)
        {
            if (m_CurID != id)
            {
                SkinnedMeshRenderer newSkin = null;
                if (m_Slot == AppearanceSlot.HelmetWithHead)
                {
                    newSkin = CharacterHolder.S.GetHelmetMesh(id);

                }
                else
                {
                    newSkin = CharacterHolder.S.GetMeshBySlot(m_Slot, sex, id);
                }

                List<Transform> bones = new List<Transform>();
                foreach (Transform bone in newSkin.bones)
                {
                    foreach (Transform hip in m_Character.bones.bones)
                    {
                        if (hip.name != bone.name)
                        {
                            continue;
                        }
                        bones.Add(hip);
                        break;
                    }
                }

                m_Renderer.sharedMesh = newSkin.sharedMesh;
                m_Renderer.bones = bones.ToArray();
                m_CurID = id;
            }

            m_IsHide = false;
            gameObject.SetActive(true);
            return m_CurID;
        }

        public void SetHide(bool ishide)
        {
            m_IsHide = ishide;
        }

        public void BeforeCombine()
        {
            gameObject.SetActive(!m_IsHide);
        }
    }

}