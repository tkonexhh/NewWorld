/************************
	FileName:/Scripts/Game/Character/SkinApperaance.cs
	CreateAuthor:neo.xu
	CreateTime:7/2/2020 3:58:25 PM
	Tip:7/2/2020 3:58:25 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public class SkinApperaance : MonoBehaviour
    {
        [SerializeField] AppearanceSlot m_Slot;
        [SerializeField] private SkinnedMeshRenderer m_Renderer;

        private int m_CurID;
        private CharacterAppearance m_Character;

        public int curID => m_CurID;

        public void Init(CharacterAppearance character)
        {
            if (m_Renderer == null)
                m_Renderer = GetComponent<SkinnedMeshRenderer>();

            m_Character = character;
            m_CurID = -100;
        }

        public int SetSkin(Sex sex, int id, params object[] args)
        {
            if (m_CurID != id)
            {
                if (id == -1)
                {
                    m_Renderer.sharedMesh = null;
                }
                else
                {
                    if (GameResMgr.S.globalRes.roleHolder == null)
                    {
                        return m_CurID;
                    }
                    SkinnedMeshRenderer newSkin = GameResMgr.S.globalRes.roleHolder.GetMeshBySlot(m_Slot, sex, id, args);


                    List<Transform> bones = new List<Transform>();
                    foreach (Transform bone in newSkin.bones)
                    {
                        foreach (Transform hip in m_Character.bone.bones)
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

                }
                m_CurID = id;

            }

            gameObject.SetActive(id != -1);
            return m_CurID;
        }


        public void BeforeCombine()
        {
            gameObject.SetActive(true);
        }
    }

}