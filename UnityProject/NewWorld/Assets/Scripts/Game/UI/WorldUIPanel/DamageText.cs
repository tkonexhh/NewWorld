using System;
/************************
	FileName:/Scripts/Game/UI/WorldUIPanel/DamageText.cs
	CreateAuthor:neo.xu
	CreateTime:11/9/2020 3:16:03 PM
	Tip:11/9/2020 3:16:03 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening.Core.Easing;
using DG.Tweening;
using System;
using GFrame;

namespace Game.Logic
{

    public enum DamageTextEnum
    {
        Normal,
        Crit,//暴击
    }


    public class DamageText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_TMP;

        // private float startTime;
        // private float m_TargetScale = 1.1f;
        // private float m_AnimTime = 1.0f;
        // private Vector3 m_StartPos;
        // private Vector3 m_TargetPos;
        // private Action m_CompleteCallBack;

        public void ShowDamage(DamageTextEnum type, int num, Action callback = null)
        {
            // m_CompleteCallBack = callback;
            m_TMP.text = num.ToString();
            switch (type)
            {
                case DamageTextEnum.Normal:
                    m_TMP.color = Color.white;
                    break;
                case DamageTextEnum.Crit:
                    m_TMP.color = Color.yellow;
                    break;
            }
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, 0.4f);
            transform.DOLocalMove(transform.localPosition + new Vector3(UnityEngine.Random.Range(-30, 30), UnityEngine.Random.Range(-30, 30), 0), 1.0f)
            .OnComplete(() =>
            {
                if (callback != null)
                    callback.Invoke();
            });
            // m_StartPos = transform.localPosition;
            // m_TargetPos = transform.localPosition + new Vector3(UnityEngine.Random.Range(-20, 20), UnityEngine.Random.Range(-20, 20), 0);

            // 
            // startTime = Time.realtimeSinceStartup;
        }

        // public void Trick()
        // {
        //     float passedTime = Time.realtimeSinceStartup - startTime;
        //     float v = EaseManager.Evaluate(Ease.Linear, null, passedTime, m_AnimTime, 0, 0);
        //     float scaleValue = Mathf.Lerp(0, m_TargetScale, v);

        //     if (Mathf.Abs(m_TargetScale - scaleValue) < 0.01f)
        //     {
        //         scaleValue = m_TargetScale;
        //         if (m_CompleteCallBack != null)
        //         {
        //             m_CompleteCallBack.Invoke();
        //         }
        //     }

        //     transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);

        //     float v2 = EaseManager.Evaluate(Ease.InBounce, null, passedTime, m_AnimTime, 0, 0);
        //     Vector3 tempPos = transform.localPosition;
        //     tempPos = Vector3.Lerp(m_StartPos, m_TargetPos, v);
        //     transform.localPosition = tempPos;
        // }


    }

}