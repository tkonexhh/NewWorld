/************************
	FileName:/GFrameWork/Scripts/Engine/DataRecord/PlayerPrefs/DataRecorder.cs
	CreateAuthor:neo.xu
	CreateTime:6/30/2020 11:14:54 AM
	Tip:6/30/2020 11:14:54 AM
************************/

using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class DataRecorder : IDataRecord, IEventListener
    {
        #region RecordCell
        class RecordCell
        {
            private string m_Key;
            private string m_Value;

            public string stringValue
            {
                get { return m_Value; }
                set { m_Value = value; }
            }

            public bool boolValue
            {
                get { return "1".Equals(m_Value); }
                set
                {
                    if (value)
                    {
                        m_Value = "1";
                    }
                    else
                    {
                        m_Value = "0";
                    }
                }
            }

            public int intValue
            {
                get
                {
                    if (string.IsNullOrEmpty(m_Value))
                    {
                        return 0;
                    }

                    return int.Parse(m_Value);
                }
                set { m_Value = value.ToString(); }
            }

            public float floatValue
            {
                get
                {
                    if (string.IsNullOrEmpty(m_Value))
                    {
                        return 0;
                    }
                    return float.Parse(m_Value);
                }
                set { m_Value = value.ToString(); }
            }

            public string key
            {
                get { return m_Key; }
                set { m_Key = value; }
            }

            public void SetData(string data)
            {
                m_Key = data.Substring(0, data.IndexOf(':'));
                m_Value = data.Substring(data.IndexOf(':') + 1);
            }

            public void WriteData(StringBuilder builder)
            {
                builder.Append("|");
                builder.Append(m_Key);
                builder.Append(":");
                builder.Append(m_Value);
            }
        }

        #endregion

        private static string SaveKey = "DataRecord";
        private Dictionary<string, RecordCell> m_RecordMap = new Dictionary<string, RecordCell>();
        private bool m_IsDataDirty = false;
        public void Init()
        {
            EventSystem.S.Register(EngineEventID.OnApplicationQuit, HandleEvent);
            Load();
        }

        public void Reset() { }
        public void Save()
        {
            if (m_IsDataDirty)
            {
                string s = SerializeData();
                PlayerPrefs.SetString(SaveKey, s);
                PlayerPrefs.Save();
                m_IsDataDirty = false;
            }
        }

        private void Load()
        {
            m_RecordMap.Clear();
            string s = PlayerPrefs.GetString(SaveKey, "");
            DeserializeData(s);
        }

        public bool GetBool(string key, bool defaultValue = false)
        {
            RecordCell cell = null;
            if (!m_RecordMap.TryGetValue(key, out cell))
            {
                return defaultValue;
            }

            return cell.boolValue;
        }

        public void SetBool(string key, bool value)
        {
            RecordCell cell = null;
            if (!m_RecordMap.TryGetValue(key, out cell))
            {
                cell = new RecordCell();
                cell.key = key;
                m_RecordMap.Add(key, cell);
            }

            cell.boolValue = value;
            m_IsDataDirty = true;
        }

        public string GetString(string key, string defaultValue = "")
        {
            RecordCell cell = null;
            if (!m_RecordMap.TryGetValue(key, out cell))
            {
                return defaultValue;
            }

            return cell.stringValue;
        }

        public void SetString(string key, string value)
        {
            RecordCell cell = null;
            if (!m_RecordMap.TryGetValue(key, out cell))
            {
                cell = new RecordCell();
                cell.key = key;
                m_RecordMap.Add(key, cell);
            }

            cell.stringValue = value;
            m_IsDataDirty = true;
        }

        public float GetFloat(string key, float defaultValue = 0)
        {
            RecordCell cell = null;
            if (!m_RecordMap.TryGetValue(key, out cell))
            {
                return defaultValue;
            }

            return cell.floatValue;
        }

        public void SetFloat(string key, float value)
        {
            RecordCell cell = null;
            if (!m_RecordMap.TryGetValue(key, out cell))
            {
                cell = new RecordCell();
                cell.key = key;
                m_RecordMap.Add(key, cell);
            }

            cell.floatValue = value;
            m_IsDataDirty = true;
        }

        public int GetInt(string key, int defaultValue = 0)
        {
            RecordCell cell = null;
            if (!m_RecordMap.TryGetValue(key, out cell))
            {
                return defaultValue;
            }

            return cell.intValue;
        }
        public void SetInt(string key, int value)
        {
            RecordCell cell = null;
            if (!m_RecordMap.TryGetValue(key, out cell))
            {
                cell = new RecordCell();
                cell.key = key;
                m_RecordMap.Add(key, cell);
            }

            cell.intValue = value;
            m_IsDataDirty = true;
        }


        private void DeserializeData(string data)
        {
            string[] values = data.Split('|');

            for (int i = 0; i < values.Length; ++i)
            {
                if (string.IsNullOrEmpty(values[i]))
                {
                    continue;
                }

                RecordCell cell = new RecordCell();
                cell.SetData(values[i]);

                m_RecordMap.Add(cell.key, cell);
            }
        }

        private string SerializeData()
        {
            if (m_RecordMap != null)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var item in m_RecordMap)
                {
                    item.Value.WriteData(builder);
                }

                return builder.ToString();
            }

            return "";
        }

        public void HandleEvent(int key, params object[] args)
        {
            switch (key)
            {
                case (int)EngineEventID.OnApplicationQuit:
                    Debug.LogError("OnApplicationQuit");
                    Save();
                    break;
            }
        }
    }

}