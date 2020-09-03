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

namespace Game.Logic
{
    public class GameDataMgr : TSingleton<GameDataMgr>
    {
        public override void OnSingletonInit()
        {
            InitCharacterAppearanceData();
            InitItemData();
            InitEquipmentData();
        }

        public void Init()
        {
            Log.i("Init[GameDataMgr]");
        }

        private void InitCharacterAppearanceData()
        {
            var database = SQLMgr.S.Open("Game");
            var reader = database.LoadTable("CharacterAppearance");
            while (reader.Read())
            {
                TDCharacterAppearanceTable.OnAddRow(reader);
            }
        }

        private void InitEquipmentData()
        {
            var database = SQLMgr.S.Open("Game");
            var reader = database.LoadTable("Equipment");
            while (reader.Read())
            {
                TDEquipmentTable.OnAddRow(reader);
            }
        }

        private void InitItemData()
        {
            var database = SQLMgr.S.Open("Game");
            var reader = database.LoadTable("Item");
            while (reader.Read())
            {
                TDItemTable.OnAddRow(reader);
            }
        }

    }

}