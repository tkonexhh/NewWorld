/************************
	FileName:/Scripts/Game/Mgr/GameDataMgr.cs
	CreateAuthor:neo.xu
	CreateTime:7/6/2020 4:11:33 PM
	Tip:7/6/2020 4:11:33 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;

namespace GameWish.Game
{
    public class GameDataMgr : TSingleton<GameDataMgr>
    {
        public override void OnSingletonInit()
        {
            InitCharacterAppearanceData();
            InitEquipmentData();
        }

        public void Init()
        {

        }

        private void InitCharacterAppearanceData()
        {
            var database = SQLMgr.S.Open("Game");
            var reader = database.LoadTable("CharacterAppearance");
            while (reader.Read())
            {
                TDCharacterAppearanceTable.Parse(reader);

            }
        }

        private void InitEquipmentData()
        {
            var database = SQLMgr.S.Open("Game");
            var reader = database.LoadTable("Equipment");
            while (reader.Read())
            {
                int id = (int)reader[0];
                string name = reader[1].ToString();
                EquipmentType type = StringToEquipmentType(reader[2].ToString());
                int appearance = (int)reader[3];
            }
        }

        private EquipmentType StringToEquipmentType(string value)
        {
            switch (value)
            {
                case "Helmet":
                    return EquipmentType.Helmet;
                case "Torso":
                    return EquipmentType.Torso;
                default:
                    return EquipmentType.Length;
            }

        }

    }

}