/************************
	FileName:/Scripts/Game/Module/Inventory/Base/ScorlInventoryViewData.cs
	CreateAuthor:neo.xu
	CreateTime:9/1/2020 8:32:51 PM
	Tip:9/1/2020 8:32:51 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    //格子样式
    public class ScorllInventoryViewData : AbstractInventoryViewData
    {
        public int width { get; }
        public int height { get; }

        bool[] mask;


        public ScorllInventoryViewData(IInventoryCellData[] cellData, int capacityWidth, int capacityHeight) : base(cellData)
        {
            Debug.Assert(cellData.Length == capacityWidth * capacityHeight);

            width = capacityWidth;
            height = capacityHeight;

            UpdateMask();
        }

        #region IInventoryViewData
        public override int? GetId(IInventoryCellData cellData)
        {
            for (var i = 0; i < CellData.Length; i++)
            {
                if (CellData[i] == cellData)
                {
                    return i;
                }
            }

            return null;
        }

        public override int? GetInsertableId(IInventoryCellData cellData)
        {
            for (var i = 0; i < mask.Length; i++)
            {
                if (!mask[i] && CheckInsert(i, cellData))
                {
                    return i;
                }
            }

            return null;
        }

        public override void InsertInventoryItem(int id, IInventoryCellData cellData)
        {
            CellData[id] = cellData;
            IsDirty = true;

            UpdateMask();
        }

        public override bool CheckInsert(int id, IInventoryCellData cellData)
        {
            if (id < 0)
            {
                return false;
            }
            var width = cellData.Width;
            var height = cellData.Height;

            // check width
            if ((id % this.width) + (width - 1) >= this.width)
            {
                return false;
            }

            // check height
            if (id + ((height - 1) * this.width) >= CellData.Length)
            {
                return false;
            }

            for (var i = 0; i < width; i++)
            {
                for (var t = 0; t < height; t++)
                {
                    if (mask[id + i + (t * this.width)])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override void Clear()
        {

        }

        #endregion

        public void ExchangeInventoryItem(int id1, int id2)
        {
            var data = CellData[id1];
            CellData[id1] = CellData[id2];
            CellData[id2] = data;
            IsDirty = true;
            UpdateMask();
        }

        protected void UpdateMask()
        {
            mask = new bool[width * height];

            for (var i = 0; i < CellData.Length; i++)
            {
                if (CellData[i] == null || mask[i])
                {
                    continue;
                }

                var width = CellData[i].Width;
                var height = CellData[i].Height;

                for (var w = 0; w < width; w++)
                {
                    for (var h = 0; h < height; h++)
                    {
                        var checkIndex = i + w + (h * this.width);
                        if (checkIndex < mask.Length)
                        {
                            mask[checkIndex] = true;
                        }
                    }
                }
            }
        }
    }

}