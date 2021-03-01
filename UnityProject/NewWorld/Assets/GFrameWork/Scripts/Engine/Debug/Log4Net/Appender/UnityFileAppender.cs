/************************
	FileName:/GFrameWork/Scripts/Engine/Debug/Log4Net/Appender/UnityFileAppender.cs
	CreateAuthor:neo.xu
	CreateTime:3/1/2021 3:10:47 PM
	Tip:3/1/2021 3:10:47 PM
************************/

using System.IO;
using log4net.Core;
using log4net.Appender;
using UnityEngine;


namespace GFrame.Debugger.Log4Net.Appender
{
    public class UnityFileAppender : FileAppender
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
                // Debug.LogError(path);
            }
        }
    }

}