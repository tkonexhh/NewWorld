﻿//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2017 SnowCold. All rights reserved.
//  WebSite:     https://github.com/SnowCold/Qarth
//  Blog:        http://blog.csdn.net/snowcoldgame
//  Author:      SnowCold
//  E-mail:      snowcold.ouyang@gmail.com
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

namespace GFrame
{
    public class UGridListView : IUListView
    {
        [SerializeField] private int m_MaxRow;
        [SerializeField] private int m_MaxCol;
        public Alignment alignment = Alignment.Mid;

        private int numPerRow;
        private int numPerColumn;
        private Vector2 itemSize;

        public override void Init()
        {
            base.Init();

            itemSize = itemPrefab.GetItemSize(-1);

            // record max numbers per row/column
            numPerRow = m_MaxRow;
            numPerColumn = m_MaxCol;

            if (numPerRow < 1)
            {
                numPerRow = (int)(scrollRectSize.x / (itemSize.x + spacing.x));
            }

            if (numPerColumn < 1)
            {
                numPerColumn = (int)(scrollRectSize.y / (itemSize.y + spacing.y));
            }

            if (numPerRow < 1 || numPerColumn < 1)
            {
                Debug.LogError("ScrollRect size is too small to contain even one item");
            }

            // to make items center aligned
            //padding = Vector2.zero;

            // spawn pool for listitems
            lstItems = new List<GameObject>();
        }

        protected override void AdjustViewportSize(Vector2 contentSize)
        {
            // if (alignment == Alignment.Mid)
            // {
            //     Debug.LogError(111);
            //     if (contentSize.x < scrollRectSize.x || contentSize.y < scrollRectSize.y)
            //     {

            //         viewPort.sizeDelta = contentSize;
            //         viewPort.anchoredPosition = new Vector2(contentSize.x * -0.5f, contentSize.y * 0.5f);
            //     }
            // }
        }

        public override int GetMaxShowItemNum()
        {
            int max = 0;
            // calculate the max show nums
            switch (layout)
            {
                case Layout.Horizontal:
                    max = ((int)(scrollRectSize.x / itemSize.x) + 2) * numPerColumn;
                    break;
                case Layout.Vertical:
                    max = ((int)(scrollRectSize.y / itemSize.y) + 2) * numPerRow;
                    break;
            }
            return max;
        }

        public override int GetStartIndex()
        {
            Vector2 anchorPosition = content.anchoredPosition;
            anchorPosition.x *= -1;
            int index = 0;

            switch (layout)
            {
                case Layout.Vertical:
                    index = (int)(anchorPosition.y / (itemSize.y + spacing.y)) * numPerRow;
                    break;
                case Layout.Horizontal:
                    index = (int)(anchorPosition.x / (itemSize.x + spacing.x)) * numPerColumn;
                    break;
            }
            if (index < 0) index = 0;
            if (index >= lstCount) index = 0;
            return index;
        }

        public override Vector2 GetItemAnchorPos(int index)
        {
            Vector2 basePos = Vector2.zero;
            Vector2 offset = Vector2.zero;
            RectTransform contentRectTransform = content.transform as RectTransform;
            Vector2 contentRectSize = contentRectTransform.rect.size;

            if (layout == Layout.Horizontal)
            {
                int offsetIndex = index % numPerColumn;
                basePos.x = -contentRectSize.x / 2 + itemSize.x / 2;
                offset.x = (index / numPerColumn) * (itemSize.x + spacing.x);
                offset.y = contentRectSize.y / 2 - itemSize.y / 2 - offsetIndex * (itemSize.y + spacing.y);
            }
            else
            {
                int offsetIndex = index % numPerRow;
                basePos.y = contentRectSize.y / 2 - itemSize.y / 2;
                offset.y = -(index / numPerRow) * (itemSize.y + spacing.y);
                offset.x = -(contentRectSize.x - itemSize.x) / 2 + offsetIndex * (itemSize.x + spacing.x);
            }

            return basePos + offset + padding + new Vector2(-padding.x, 0);
        }

        public override Vector2 GetContentSize()
        {
            Vector2 size = scrollRectSize;
            int count = lstCount;

            switch (layout)
            {
                case Layout.Horizontal:
                    count = (count + numPerColumn - 1) / numPerColumn;
                    size.x = itemSize.x * count + spacing.x * (count > 0 ? count - 1 : count);
                    size.x -= padding.x * 2;
                    break;
                case Layout.Vertical:
                    count = (count + numPerRow - 1) / numPerRow;
                    size.y = itemSize.y * count + spacing.y * (count > 0 ? count - 1 : count);
                    size.y -= padding.y * 2;
                    break;
            }
            return size;
        }

        public override GameObject GetItemGameObject(Transform content, int index)
        {
            if (index < lstItems.Count)
            {
                GameObject go = lstItems[index];
                if (false == go.activeSelf)
                {
                    go.SetActive(true);
                }
                return lstItems[index];
            }
            else
            {
                GameObject go = GameObject.Instantiate(itemPrefab.gameObject, content, false) as GameObject;
                lstItems.Add(go);
                return go;
            }
        }

        public override void HideNonuseableItems()
        {
            for (int i = lstCount; lstItems != null && i < lstItems.Count; ++i)
            {
                if (lstItems[i].activeSelf)
                {
                    lstItems[i].SetActive(false);
                }
            }
        }

        public override Vector2 GetItemSize(int index)
        {
            return itemSize;
        }
    }
}
