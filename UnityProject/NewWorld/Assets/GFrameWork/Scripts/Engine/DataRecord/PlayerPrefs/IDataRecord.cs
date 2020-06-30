/************************
	FileName:/GFrameWork/Scripts/Engine/DataRecord/PlayerPrefs/IDataRecord.cs
	CreateAuthor:neo.xu
	CreateTime:6/30/2020 11:10:57 AM
	Tip:6/30/2020 11:10:57 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public interface IDataRecord
    {
        void Init();
        void Reset();
        void Save();

        bool GetBool(string key, bool defaultValue = false);
        void SetBool(string key, bool value);
        string GetString(string key, string defaultValue = "");
        void SetString(string key, string value);
        float GetFloat(string key, float defaultValue = 0);
        void SetFloat(string key, float value);
        int GetInt(string key, int defaultValue = 0);
        void SetInt(string key, int value);
    }

    public class DataRecord
    {
        private static IDataRecord s_Record;
        public static IDataRecord S
        {
            get
            {
                if (s_Record == null)
                {
                    s_Record = new DataRecorder();
                    s_Record.Init();
                }
                return s_Record;
            }
        }
    }

}