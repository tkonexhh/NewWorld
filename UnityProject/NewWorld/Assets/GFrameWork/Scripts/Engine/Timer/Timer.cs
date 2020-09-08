﻿//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2017 SnowCold. All rights reserved.
//  WebSite:     https://github.com/SnowCold/Qarth
//  Blog:        http://blog.csdn.net/snowcoldgame
//  Author:      SnowCold
//  E-mail:      snowcold.ouyang@gmail.com
using System;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    [TMonoSingletonAttribute("[GFrame]/[Tools]/[Timer]")]
    public partial class Timer : TMonoSingleton<Timer>
    {
        BinaryHeap<TimeItem> m_UnScaleTimeHeap = new BinaryHeap<TimeItem>(128, eBinaryHeapSortMode.kMin);
        BinaryHeap<TimeItem> m_ScaleTimeHeap = new BinaryHeap<TimeItem>(128, eBinaryHeapSortMode.kMin);
        private float m_CurrentUnScaleTime = -1;
        private float m_CurrentScaleTime = -1;
        protected int m_LastDay4Year;

        public float currentScaleTime
        {
            get { return m_CurrentScaleTime; }
        }

        public float currentUnScaleTime
        {
            get { return m_CurrentUnScaleTime; }
        }

        public override void OnSingletonInit()
        {
            m_UnScaleTimeHeap.Clear();
            m_ScaleTimeHeap.Clear();

            m_CurrentUnScaleTime = Time.unscaledTime;
            m_CurrentScaleTime = Time.time;

            m_LastDay4Year = DateTime.Today.DayOfYear;
            StartDateChecker();
        }

        public void StartDateChecker()
        {
            Post2Really(OnPassDayEvent, 60, -1);
        }

        private void OnPassDayEvent(int count)
        {
            int dayOfYear = DateTime.Today.DayOfYear;
            if (m_LastDay4Year != dayOfYear)
            {
                m_LastDay4Year = dayOfYear;
                EventSystem.S.Send(EngineEventID.OnDateUpdate);
            }
        }

        public void ResetMgr()
        {
            m_UnScaleTimeHeap.Clear();
            m_ScaleTimeHeap.Clear();
        }

        public void StartMgr()
        {
            m_CurrentUnScaleTime = Time.unscaledTime;
            m_CurrentScaleTime = Time.time;
        }

        #region 投递受缩放影响定时器
        public int Post2Scale(Run<int> callback, float delay, int repeat)
        {
            TimeItem item = TimeItem.Allocate(callback, delay, repeat);
            Post2Scale(item);
            return item.id;
        }

        public int Post2Scale(Run<int> callback, float delay)
        {
            TimeItem item = TimeItem.Allocate(callback, delay);
            Post2Scale(item);
            return item.id;
        }

        private void Post2Scale(TimeItem item)
        {
            item.sortScore = m_CurrentScaleTime + item.DelayTime();
            m_ScaleTimeHeap.Insert(item);
        }
        #endregion

        #region 投递真实时间定时器

        //投递指定时间计时器：只支持标准时间
        public int Post2Really(Run<int> callback, DateTime toTime)
        {
            float passTick = (toTime.Ticks - DateTime.Now.Ticks) / 10000000;
            if (passTick < 0)
            {
                Log.w("Timer Set Pass Time...");
                passTick = 0;
            }
            return Post2Really(callback, passTick);
        }

        public int Post2Really(Run<int> callback, float delay, int repeat)
        {
            TimeItem item = TimeItem.Allocate(callback, delay, repeat);
            Post2Really(item);
            return item.id;
        }

        public int Post2Really(Run<int> callback, float delay)
        {
            TimeItem item = TimeItem.Allocate(callback, delay);
            Post2Really(item);
            return item.id;
        }

        private void Post2Really(TimeItem item)
        {
            item.sortScore = m_CurrentUnScaleTime + item.DelayTime();
            m_UnScaleTimeHeap.Insert(item);
        }
        #endregion

        public bool Cancel(int id)
        {
            TimeItem item = TimeItem.GetTimeItemByID(id);
            if (item == null)
            {
                return false;
            }

            item.Cancel();
            return true;
        }

        public void Update()
        {
            TimeItem item = null;
            m_CurrentUnScaleTime = Time.unscaledTime;
            m_CurrentScaleTime = Time.time;

            #region 不受缩放影响定时器更新
            while ((item = m_UnScaleTimeHeap.Top()) != null)
            {
                if (!item.isEnable)
                {
                    m_UnScaleTimeHeap.Pop();
                    item.Recycle2Cache();
                    continue;
                }

                if (item.sortScore < m_CurrentUnScaleTime)
                {
                    m_UnScaleTimeHeap.Pop();

                    item.OnTimeTick();

                    if (item.isEnable && item.NeedRepeat())
                    {
                        Post2Really(item);
                    }
                    else
                    {
                        item.Recycle2Cache();
                    }
                }
                else
                {
                    break;
                }
            }
            #endregion

            #region 受缩放影响定时器更新
            while ((item = m_ScaleTimeHeap.Top()) != null)
            {
                if (!item.isEnable)
                {
                    m_ScaleTimeHeap.Pop();
                    item.Recycle2Cache();
                    continue;
                }

                if (item.sortScore < m_CurrentScaleTime)
                {
                    m_ScaleTimeHeap.Pop();

                    item.OnTimeTick();

                    if (item.isEnable && item.NeedRepeat())
                    {
                        Post2Scale(item);
                    }
                    else
                    {
                        item.Recycle2Cache();
                    }
                }
                else
                {
                    break;
                }
            }
            #endregion
        }

        public void Dump()
        {

        }
    }

}
