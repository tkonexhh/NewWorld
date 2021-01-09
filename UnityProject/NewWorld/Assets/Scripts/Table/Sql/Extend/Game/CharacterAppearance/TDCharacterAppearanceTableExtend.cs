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
                    return m_HairData.GetDataCount(sex);
                case AppearanceSlot.Head:
                    return m_HeadData.GetDataCount(sex);
                case AppearanceSlot.FacialHair:
                    return m_FacialHairData.GetDataCount(sex);
                case AppearanceSlot.EyeBrows:
                    return m_EyeBrowsData.GetDataCount(sex);
            }
            return 0;
        }

        public static TDCharacterAppearance GetAppearanceByID(AppearanceSlot slot, Sex sex, int index)
        {
            switch (slot)
            {
                case AppearanceSlot.Hair:
                    return m_HairData.GetAppearanceByID(sex, index);
                case AppearanceSlot.Head:
                    return m_HeadData.GetAppearanceByID(sex, index);
                case AppearanceSlot.FacialHair:
                    return m_FacialHairData.GetAppearanceByID(sex, index);
                case AppearanceSlot.EyeBrows:
                    return m_EyeBrowsData.GetAppearanceByID(sex, index);
            }
            return null;
        }

        public static TDCharacterAppearanceData GetAppearanceDataGroup(AppearanceSlot slot, Sex sex)
        {
            switch (slot)
            {
                case AppearanceSlot.Hair:
                    return m_HairData;
                case AppearanceSlot.Head:
                    return m_HeadData;
                case AppearanceSlot.FacialHair:
                    return m_FacialHairData;
                case AppearanceSlot.EyeBrows:
                    return m_EyeBrowsData;
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

        public virtual int GetDataCount(Sex sex)
        {
            return 0;
        }

        public virtual TDCharacterAppearance GetAppearanceByID(Sex sex, int id)
        {
            return null;
        }

        public virtual TDCharacterAppearance GetAppearanceByIndex(Sex sex, int index)
        {
            return null;
        }
    }

    public class TDCharacterAppearanceData_General : TDCharacterAppearanceData
    {
        private Dictionary<int, TDCharacterAppearance> m_DataMap = new Dictionary<int, TDCharacterAppearance>();
        private List<TDCharacterAppearance> m_LstData = new List<TDCharacterAppearance>();
        public override void OnAddData(TDCharacterAppearance conf)
        {
            m_DataMap.Add((int)conf.Appearance, conf);
            m_LstData.Add(conf);
        }

        public override int GetDataCount(Sex sex)
        {
            return m_DataMap.Count;
        }

        public override TDCharacterAppearance GetAppearanceByID(Sex sex, int id)
        {
            TDCharacterAppearance data;
            if (m_DataMap.TryGetValue(id, out data))
            {
                return data;
            }
            return null;
        }

        public override TDCharacterAppearance GetAppearanceByIndex(Sex sex, int index)
        {
            if (index < 0 || index > m_LstData.Count)
                return null;

            return m_LstData[index];
        }

    }

    public class TDCharacterAppearanceData_Sexual : TDCharacterAppearanceData
    {
        private Dictionary<int, Dictionary<long, TDCharacterAppearance>> m_DataMap = new Dictionary<int, Dictionary<long, TDCharacterAppearance>>();
        private List<TDCharacterAppearance> m_LstDataMale = new List<TDCharacterAppearance>();
        private List<TDCharacterAppearance> m_LstDataFemale = new List<TDCharacterAppearance>();

        public override void OnAddData(TDCharacterAppearance conf)
        {
            Dictionary<long, TDCharacterAppearance> map;
            if (!m_DataMap.TryGetValue((int)conf.Sex, out map))
            {
                map = new Dictionary<long, TDCharacterAppearance>();
                m_DataMap.Add((int)conf.Sex, map);
            }

            map.Add(map.Count, conf);
            if (conf.sex == Sex.Male)
            {
                m_LstDataMale.Add(conf);
            }
            else
            {
                m_LstDataFemale.Add(conf);
            }


        }


        public override int GetDataCount(Sex sex)
        {
            Dictionary<long, TDCharacterAppearance> map;
            if (m_DataMap.TryGetValue((int)sex, out map))
            {
                return map.Count;
            }
            return 0;
        }

        public override TDCharacterAppearance GetAppearanceByID(Sex sex, int id)
        {
            Dictionary<long, TDCharacterAppearance> headData;
            if (m_DataMap.TryGetValue((int)sex, out headData))
            {
                TDCharacterAppearance data;
                if (headData.TryGetValue(id, out data))
                {
                    return data;
                }
                return null;
            }
            return null;
        }

        public override TDCharacterAppearance GetAppearanceByIndex(Sex sex, int index)
        {
            if (index < 0)
                return null;
            var lstData = sex == Sex.Male ? m_LstDataMale : m_LstDataFemale;
            if (index > lstData.Count)
                return null;

            return lstData[index];
        }
    }

    #endregion
}