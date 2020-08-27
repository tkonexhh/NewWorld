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

        Coroutine longPointerCoroutine;

        public void SetActive(bool value)
        {
            enabled = value;
            foreach (var graphic in GetComponentsInChildren<Graphic>())
            {
                graphic.raycastTarget = value;
            }
        }

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

            if (PlatformHelper.isMobile)
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
            if (PlatformHelper.isMobile)
            {
                if (longPointerCoroutine != null)
                {
                    StopCoroutine(longPointerCoroutine);
                }

                longPointerCoroutine = StartCoroutine(LongPointerDownCoroutine(eventData));
            }
            else
            {
                base.OnPointerDown(eventData);
                onPointerDown?.Invoke();
            }



        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            onPointerUp?.Invoke();
        }



        IEnumerator LongPointerDownCoroutine(PointerEventData eventData)
        {
            var pressTime = Time.unscaledTime;
            var pressPosition = eventData.position;

            while (Time.unscaledTime < pressTime + 1.0f)
            {
                if ((eventData.position - pressPosition).magnitude > 10.0f)
                {
                    longPointerCoroutine = null;
                    yield break;
                }

                yield return null;
            }

            onPointerOptionClick?.Invoke();
            longPointerCoroutine = null;
            yield break;
        }

    }

}