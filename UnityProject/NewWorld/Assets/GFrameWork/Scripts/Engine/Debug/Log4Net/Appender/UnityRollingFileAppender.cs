/************************
	FileName:/GFrameWork/Scripts/Engine/Debug/Log4Net/Appender/UnityRollingFileAppender.cs
	CreateAuthor:neo.xu
	CreateTime:3/1/2021 3:37:44 PM
	Tip:3/1/2021 3:37:44 PM
************************/


using System.IO;
using UnityEngine;
using log4net.Appender;

namespace GFrame.Debugger.Log4Net.Appender
{
    public class UnityRollingFileAppender : RollingFileAppender
    {
        public override string File
        {
            set
            {
                string path;
                if (Application.isEditor)
                    path = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
                else
                    path = Path.Combine(Application.temporaryCachePath, "Logs");

                base.File = Path.Combine(path, value);
            }
        }
    }

}