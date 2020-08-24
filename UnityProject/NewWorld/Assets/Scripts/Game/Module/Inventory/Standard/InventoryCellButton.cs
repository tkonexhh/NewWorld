/************************
	FileName:/Scripts/Game/Module/Inventory/Standard/StandardCellBtn.cs
	CreateAuthor:neo.xu
	CreateTime:8/19/2020 12:52:22 PM
	Tip:8/19/2020 12:52:22 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using GFrame;

namespace Game.Logic
{
    public class InventoryCellButton : Button, IInventoryCellActions
    {

        private Action onPointerClick;
        private Action onPointerOptionClick;
        private Action onPointerEnter;
        private Action onPointerExit;
        private Action onPointerDown;
        private Action onPointerUp;

        public void SetCallback(
             Action onPointerClick,
             Action onPointerOptionClick,
             Action onPointerEnter,
             Action onPointerExit,
             Action onPointerDown,
             Action onPointerUp)
        {
            this.onPointerClick = onPointerClick;
            this.onPointerOptionClick = onPointerOptionClick;
            this.onPointerEnter = onPointerEnter;
            this.onPointerExit = onPointerExit;
            this.onPointerDown = onPointerDown;
            this.onPointerUp = onPointerUp;
        }


        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);

            if (PlatformHelper.IsAndroid || PlatformHelper.IsIOS)
            {
                onPointerClick?.Invoke();
            }
            else
            {
                if (eventData.button == PointerEventData.InputButton.Left)
                {
                    onPointerClick?.Invoke();
                }
                else
                {
                    onPointerOptionClick?.Invoke();
                }
            }
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            onPointerEnter?.Invoke();
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            onPointerExit?.Invoke();
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
#if (UNITY_IOS || UNITY_ANDROID)
            if (longPointerCoroutine != null)
            {
                StopCoroutine(longPointerCoroutine);
            }

            longPointerCoroutine = StartCoroutine(LongPointerDownCoroutine(eventData));
#endif

            base.OnPointerDown(eventData);
            onPointerDown?.Invoke();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            onPointerUp?.Invoke();
        }
    }

}