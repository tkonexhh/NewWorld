/************************
	FileName:/Scripts/Game/Entity/Character/Component/CharacterAppearanceComponent.cs
	CreateAuthor:xuhonghua
	CreateTime:8/8/2020 9:47:11 PM
	Tip:8/8/2020 9:47:11 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    public class RoleAppearanceComponent : RoleBaseComponent, IEventListener
    {
        private CharacterAppearance m_Appearance;

        public CharacterAppearance appearance => m_Appearance;

        public override void Init(Entity ownner)
        {
            base.Init(ownner);
            m_Appearance = role.gameObject.GetComponentInChildren<CharacterAppearance>();

            RegisterEvent();
        }

        #region IEventListener
        public void RegisterEvent()
        {
            EventSystem.S.Register(SetupEvent.ChangeAppearance, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeColor, HandleEvent);
        }
        public void UnRegisterEvent()
        {
            EventSystem.S.Register(SetupEvent.ChangeAppearance, HandleEvent);
            EventSystem.S.Register(SetupEvent.ChangeColor, HandleEvent);
        }

        public void HandleEvent(int key, params object[] args)
        {
            switch (key)
            {
                case (int)SetupEvent.ChangeAppearance:
                    {
                        AppearanceSlot slot = (AppearanceSlot)args[0];
                        int id = (int)args[1];
                        m_Appearance.SetAppearance(slot, id);
                        m_Appearance.CombineMeshs();
                        break;
                    }
                case (int)SetupEvent.ChangeColor:
                    {
                        AppearanceColor slot = (AppearanceColor)args[0];
                        Color color = (Color)args[1];
                        m_Appearance.SetColor(slot, color);
                        break;
                    }
            }

        }

        #endregion
    }

}