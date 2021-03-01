/************************
	FileName:/GFrameWork/Scripts/Engine/Debug/Log4Net/Appender/UnityDebugAppender.cs
	CreateAuthor:neo.xu
	CreateTime:3/1/2021 2:57:42 PM
	Tip:3/1/2021 2:57:42 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using log4net.Core;
using log4net.Appender;

namespace GFrame.Debugger.Log4Net.Appender
{
    public class UnityDebugAppender : AppenderSkeleton
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            Level level = loggingEvent.Level;
            if (Level.Fatal.Equals(level) || Level.Error.Equals(level))
            {
                Debug.LogError(RenderLoggingEvent(loggingEvent));
            }
            else if (Level.Warn.Equals(level))
            {
                Debug.LogWarning(RenderLoggingEvent(loggingEvent));
            }
            else
            {
                Debug.Log(RenderLoggingEvent(loggingEvent));
            }
        }
    }

}