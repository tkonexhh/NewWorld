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
            //数据分两种 运行是必要的数据 还有一种可以慢慢加载
            InitPreLoadData();
            InitDelayLoadData();
        }

        public void Init()
        {
            Log.i("Init[GameDataMgr]");
        }

        private void InitPreLoadData()
        {
            PreloadSqlData();
        }

        private void InitDelayLoadData()
        {

        }

        private void PreloadSqlData()
        {
            InitCharacterAppearanceData();
            InitItemData();
            InitEquipmentData();
            InitEquipmentDataAppearance();
        }

        private void ReadTable(TDSqlMetaData metaData)
        {
            var database = SQLMgr.S.Open(metaData.databaseName);
            var reader = database.LoadTable(metaData.tableName);
            while (reader.Read())
            {

                TDCharacterAppearanceTable.OnAddRow(reader);
            }
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

        private void InitEquipmentDataAppearance()
        {
            var database = SQLMgr.S.Open("Game");
            var reader = database.LoadTable("EquipmentAppearance");
            while (reader.Read())
            {
                TDEquipmentAppearanceTable.OnAddRow(reader);
            }
        }

    }

}