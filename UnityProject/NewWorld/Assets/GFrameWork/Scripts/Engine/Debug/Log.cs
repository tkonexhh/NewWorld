/************************
	FileName:/GFrameWork/Scripts/Engine/Debug/Log.cs
	CreateAuthor:neo.xu
	CreateTime:4/26/2020 11:37:31 AM
************************/


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFrame
{
    public enum LogLevel
    {
        None = 0,
        Exception = 1,
        Error = 2,
        Warning = 3,
        Normal = 4,
        Max = 5,
    }

    public class Log
    {
        private static LogLevel m_LogLevel = LogLevel.Normal;

        public static LogLevel Level
        {
            get { return m_LogLevel; }
            set { m_LogLevel = value; }
        }

        public static void i(object msg)
        {
            if (m_LogLevel < LogLevel.Normal)
            {
                return;
            }
            Debug.Log(msg);
        }

        public static void i(string msg, params object[] args)
        {
            if (m_LogLevel < LogLevel.Normal)
            {
                return;
            }
            Debug.LogFormat(msg, args);
        }

        public static void e(object msg)
        {
            if (m_LogLevel < LogLevel.Error)
            {
                return;
            }
            Debug.LogError(msg);
        }

        public static void e(Exception e)
        {
            if (m_LogLevel < LogLevel.Exception)
            {
                return;
            }
            Debug.LogException(e);
        }

        public static void e(string msg, params object[] args)
        {
            if (m_LogLevel < LogLevel.Error)
            {
                return;
            }
            Debug.LogErrorFormat(msg, args);
        }

        public static void w(object msg)
        {
            if (m_LogLevel < LogLevel.Warning)
            {
                return;
            }
            Debug.LogWarning(msg);
        }

        public static void w(string msg, params object[] args)
        {
            if (m_LogLevel < LogLevel.Warning)
            {
                return;
            }
            Debug.LogWarningFormat(msg, args);
        }
    }
}


