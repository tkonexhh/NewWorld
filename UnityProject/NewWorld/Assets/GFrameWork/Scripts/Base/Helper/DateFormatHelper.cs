/************************
	FileName:/GFrameWork/Scripts/Base/Helper/DateFormatHelper.cs
	CreateAuthor:neo.xu
	CreateTime:6/24/2020 11:32:11 AM
	Tip:6/24/2020 11:32:11 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class DateFormatHelper
    {
        public static string FormatRemainTime(long timestamp)
        {
            long day = timestamp / 86400;
            long hours = (timestamp % 86400) / 3600;
            long minute = (timestamp % 3600) / 60;
            long second = (timestamp % 60);
            string dayFormat = ":";
            string hoursFormat = ":";
            string minuteFormat = ":";
            string secondFormat = "";
            if (day >= 1)
            {
                // a天b时c分d秒
                return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                    day.ToString().PadLeft(2, '0'),
                    dayFormat,
                    hours.ToString().PadLeft(2, '0'),
                    hoursFormat,
                    minute.ToString().PadLeft(2, '0'),
                    minuteFormat,
                    second.ToString().PadLeft(2, '0'),
                    secondFormat);
            }
            else
            {
                if (hours >= 1)
                {
                    // b时c分d秒
                    return string.Format("{0}{1}{2}{3}{4}{5}",
                    hours.ToString().PadLeft(2, '0'),
                    hoursFormat,
                    minute.ToString().PadLeft(2, '0'),
                    minuteFormat,
                    second.ToString().PadLeft(2, '0'),
                    secondFormat);
                }
                else
                {
                    if (minute >= 1)
                    {
                        // c分d秒
                        return string.Format("{0}{1}{2}{3}",
                        minute.ToString().PadLeft(2, '0'),
                        minuteFormat,
                        second.ToString().PadLeft(2, '0'),
                        secondFormat);
                    }
                    else
                    {
                        // d秒
                        return string.Format("{0}{1}",
                        second.ToString().PadLeft(2, '0'),
                        secondFormat);
                    }
                }
            }
        }
    }
}