using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Game.Logic
{
    public partial class TDCharacterAppearanceTable
    {
        private static TDCharacterAppearanceData_General m_HairData = new TDCharacterAppearanceData_General();
        private static TDCharacterAppearanceData_Sexual m_HeadData = new TDCharacterAppearanceData_Sexual();
        private static TDCharacterAppearanceData_Sexual m_FacialHairData = new TDCharacterAppearanceData_Sexual();
        private static TDCharacterAppearanceData_Sexual m_EyeBrowsData = new TDCharacterAppearanceData_Sexual();
        static void CompleteRowAdd(TDCharacterAppearance tdData)
        {
            switch (CharacterEnumHelper.GetSlotByName(tdData.Part))
            {
                case AppearanceSlot.Hair:
                    m_HairData.OnAddData(tdData);
                    break;
                case AppearanceSlot.Head:
                    m_HeadData.OnAddData(tdData);
                    break;
                case AppearanceSlot.FacialHair:
                    m_FacialHairData.OnAddData(tdData);
                    break;
                case AppearanceSlot.EyeBrows:
                    m_EyeBrowsData.OnAddData(tdData);
                    break;
            }
        }
    }



    public partial class TDCharacterAppearanceTable
    {
        public static int GetAppearanceCount(AppearanceSlot slot, Sex sex)
        {
            switch (slot)
            {
                case AppearanceSlot.Hair:
                    return m_HairData.GetDataCount();//m_HairDataMap.Count;
                case AppearanceSlot.Head:
                    return m_HeadData.GetDataCount(sex);
                case AppearanceSlot.FacialHair:
                    return m_FacialHairData.GetDataCount(sex);
                case AppearanceSlot.EyeBrows:
                    return m_EyeBrowsData.GetDataCount(sex);
            }
            return 0;
        }

        public static TDCharacterAppearance GetAppearanceByIndex(AppearanceSlot slot, Sex sex, int index)
        {
            switch (slot)
            {
                case AppearanceSlot.Hair:
                    return m_HairData.GetAppearanceByIndex(index);
                case AppearanceSlot.Head:
                    return m_HeadData.GetAppearanceByIndex(sex, index);
                case AppearanceSlot.FacialHair:
                    return m_FacialHairData.GetAppearanceByIndex(sex, index);
                case AppearanceSlot.EyeBrows:
                    return m_EyeBrowsData.GetAppearanceByIndex(sex, index);
            }
            return null;
        }
    }

    #region dataclass
    public class TDCharacterAppearanceData
    {
        public virtual void OnAddData(TDCharacterAppearance conf)
        {
        }
    }

    public class TDCharacterAppearanceData_General : TDCharacterAppearanceData
    {
        private Dictionary<long, TDCharacterAppearance> m_DataMap = new Dictionary<long, TDCharacterAppearance>();
        public override void OnAddData(TDCharacterAppearance conf)
        {
            m_DataMap.Add(m_DataMap.Count, conf);
        }

        public int GetDataCount()
        {
            return m_DataMap.Count;
        }

        public TDCharacterAppearance GetAppearanceByIndex(int index)
        {
            TDCharacterAppearance data;
            if (m_DataMap.TryGetValue(index, out data))
            {
                return data;
            }
            return null;
        }
    }

    public class TDCharacterAppearanceData_Sexual : TDCharacterAppearanceData
    {
        private Dictionary<int, Dictionary<long, TDCharacterAppearance>> m_DataMap = new Dictionary<int, Dictionary<long, TDCharacterAppearance>>();

        public override void OnAddData(TDCharacterAppearance conf)
        {
            Dictionary<long, TDCharacterAppearance> map;
            if (!m_DataMap.TryGetValue((int)conf.Sex, out map))
            {
                map = new Dictionary<long, TDCharacterAppearance>();
                m_DataMap.Add((int)conf.Sex, map);
            }

            map.Add(map.Count, conf);
        }

        public int GetDataCount(Sex sex)
        {
            Dictionary<long, TDCharacterAppearance> map;
            if (m_DataMap.TryGetValue((int)sex, out map))
            {
                return map.Count;
            }
            return 0;
        }

        public TDCharacterAppearance GetAppearanceByIndex(Sex sex, int index)
        {
            Dictionary<long, TDCharacterAppearance> headData;
            if (m_DataMap.TryGetValue((int)sex, out headData))
            {
                TDCharacterAppearance data;
                if (headData.TryGetValue(index, out data))
                {
                    return data;
                }
                return null;
            }
            return null;
        }
    }

    #endregion
}