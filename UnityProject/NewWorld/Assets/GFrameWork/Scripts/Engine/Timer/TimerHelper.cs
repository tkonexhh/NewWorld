using System;
using System.Collections.Generic;

namespace GFrame
{
    public class TimerHelper
    {
        protected List<int> m_TimeItemList;
        protected bool m_IsUseAble = true;

        public void Add(int item)
        {
            if (!m_IsUseAble)
            {
                Log.e("TimeHelper Not Use Able...");
                return;
            }

            if (m_TimeItemList == null)
            {
                m_TimeItemList = new List<int>(2);
            }
            m_TimeItemList.Add(item);
        }

        public void Clear()
        {
            if (m_TimeItemList != null)
            {
                for (int i = m_TimeItemList.Count - 1; i >= 0; --i)
                {
                    Timer.S.Cancel(m_TimeItemList[i]);
                }

                m_TimeItemList.Clear();
            }
        }
    }
}
