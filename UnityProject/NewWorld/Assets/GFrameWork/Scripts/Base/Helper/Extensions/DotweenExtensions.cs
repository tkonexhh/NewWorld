/************************
	FileName:/GFrameWork/Scripts/Base/Helper/Extensions/DotweenExtensions.cs
	CreateAuthor:neo.xu
	CreateTime:7/14/2020 7:48:08 PM
	Tip:7/14/2020 7:48:08 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace GFrame
{
    public static class DotweenExtensions
    {
        public delegate float FloatGetter();
        public delegate void FloatSetter(float x);

        public static Tweener DoScrollHorizontal(this ScrollRect target, float endValue, float duration)
        {
            DG.Tweening.Core.DOSetter<float> setter = (x) => { target.horizontalNormalizedPosition = x; };

            return DOTween.To(setter, target.horizontalNormalizedPosition, endValue, duration);
        }

        public static Tweener DoScrollVertical(this ScrollRect target, float endValue, float duration)
        {
            DG.Tweening.Core.DOSetter<float> setter = (x) => { target.verticalNormalizedPosition = x; };

            return DOTween.To(setter, target.verticalNormalizedPosition, endValue, duration);
        }
    }

}