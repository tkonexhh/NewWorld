/************************
	FileName:/Scripts/Data/InventoryViewData.cs
	CreateAuthor:neo.xu
	CreateTime:8/18/2020 11:38:47 AM
	Tip:8/18/2020 11:38:47 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class AbstractInventoryViewData : IInventoryViewData
    {
        public bool IsDirty { get; set; }

        public IInventoryCellData[] CellData { get; }

        public int width { get; }
        public int height { get; }

        bool[] mask;


        public AbstractInventoryViewData(int capacityWidth, int capacityHeight)
                    : this(new IInventoryCellData[capacityWidth * capacityHeight], capacityWidth, capacityHeight)
        {
        }

        public AbstractInventoryViewData(IInventoryCellData[] cellData, int capacityWidth, int capacityHeight)
        {
            Debug.Assert(cellData.Length == capacityWidth * capacityHeight);

            IsDirty = true;
            CellData = cellData;
            width = capacityWidth;
            height = capacityHeight;

            UpdateMask();
        }


        public virtual int? GetId(IInventoryCellData cellData)
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

        public virtual int? GetInsertableId(IInventoryCellData cellData)
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

        public virtual void InsertInventoryItem(int id, IInventoryCellData cellData)
        {
            CellData[id] = cellData;
            IsDirty = true;

            UpdateMask();
        }

        public virtual bool CheckInsert(int id, IInventoryCellData cellData)
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