/************************
	FileName:/GFrameWork/Scripts/Engine/Debug/Log4Net/Log4NetLog.cs
	CreateAuthor:neo.xu
	CreateTime:3/1/2021 2:23:29 PM
	Tip:3/1/2021 2:23:29 PM
************************/

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using log4net;
using log4net.Config;

namespace GFrame
{
    public class Log4NetLog : ILog
    {
        private static readonly string config_path = "";
        private static log4net.ILog logger = LogManager.GetLogger("Log4NetLog");

        public Log4NetLog()
        {
            string configFileName = "Log4NetConfig";
            TextAsset configText = Resources.Load<TextAsset>(configFileName);
            if (configText != null)
            {
                using (MemoryStream memoryStream = new MemoryStream(configText.bytes))
                {
                    log4net.Config.XmlConfigurator.Configure(memoryStream);
                }
            }
        }

        public void i(object msg)
        {
            logger.Info(msg);
        }
        public void i(string msg, params object[] args)
        {
            logger.InfoFormat(msg, args);
        }
        public void e(object msg)
        {
            logger.Error(msg);
        }
        public void e(Exception e)
        {
            // logger.Error()
        }
        public void e(string msg, params object[] args)
        {
            Debug.LogErrorFormat(msg, args);
        }
        public void w(object msg)
        {
            logger.Warn(msg);
        }

        public void w(string msg, params object[] args)
        {
            logger.WarnFormat(msg, args);
        }
    }

}