/************************
	FileName:/Scripts/Game/Item/InteractableItem/Chest/Chest.cs
	CreateAuthor:neo.xu
	CreateTime:11/27/2020 3:54:16 PM
	Tip:11/27/2020 3:54:16 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Game.Logic
{
    public class Chest : InteractableObject
    {
        [SerializeField] private Transform m_TransLid;

        private bool m_InterActing = false;
        private bool m_IsOpen = false;


        protected override void OnInit()
        {
            m_IsOpen = false;
        }

        public override void Interact(Role role)
        {
            OpenChest();
        }

        public override void InteractOver(Role role)
        {
            CloseChest();
        }

        public void OpenChest()
        {
            if (m_InterActing)
                return;

            if (m_IsOpen)
                return;

            m_IsOpen = true;
            m_InterActing = true;
            m_TransLid.DOKill();
            m_TransLid.DOLocalRotateQuaternion(Quaternion.Euler(new Vector3(-135, 0, 0)), 1.0f)
            .SetEase(Ease.InCubic)
            .OnComplete(() =>
            {
                m_InterActing = false;
            });
        }


        public void CloseChest()
        {
            if (m_InterActing)
                return;

            if (!m_IsOpen)
                return;

            m_IsOpen = false;
            m_InterActing = true;
            m_TransLid.DOKill();
            m_TransLid.DOLocalRotateQuaternion(Quaternion.Euler(Vector3.zero), 1.0f)
            .SetEase(Ease.InCubic)
            .OnComplete(() =>
            {
                m_InterActing = false;
            });
        }
    }

}