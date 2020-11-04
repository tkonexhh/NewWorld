/************************
	FileName:/GFrameWork/Scripts/Base/Helper/StringHelper.cs
	CreateAuthor:neo.xu
	CreateTime:7/3/2020 5:29:29 PM
	Tip:7/3/2020 5:29:29 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Security;


namespace GFrame
{
    public class StringHelper
    {
        public static string Concat(params string[] args)
        {
            string str = "";
            for (int i = 0; i < args.Length; i++)
            {
                str += args[i];
            }
            return str;
        }




        public static List<int> String2ListInt(string value, string splitter = ";")
        {
            List<int> list = new List<int>();

            if (string.IsNullOrEmpty(value) || splitter == null)
            {
                return list;
            }

            string[] strArray = value.Split(splitter[0]);

            for (int i = 0; i < strArray.Length; i++)
            {
                list.Add(StringHelper.String2Int(strArray[i]));
            }

            return list;
        }

        public static object[] String2ObjectArray(string value, string splitter = ";")
        {

            if (string.IsNullOrEmpty(value) || splitter == null)
            {
                return new string[0];
            }

            string[] strArray = value.Split(splitter[0]);
            return strArray;
        }

        public static List<float> String2ListFloat(string value, string splitter = ";")
        {
            List<float> list = new List<float>();

            if (string.IsNullOrEmpty(value) || splitter == null)
            {
                return list;
            }

            string[] strArray = value.Split(splitter[0]);

            for (int i = 0; i < strArray.Length; i++)
            {
                list.Add(StringHelper.String2Float(strArray[i]));
            }

            return list;
        }

        public static List<bool> String2ListBool(string value, string splitter = ";")
        {
            List<bool> list = new List<bool>();
            if (string.IsNullOrEmpty(value) || splitter == null)
            {
                return list;
            }

            string[] strArray = value.Split(splitter[0]);

            for (int i = 0; i < strArray.Length; i++)
            {
                list.Add(StringHelper.String2Bool(strArray[i]));
            }

            return list;
        }

        public static List<string> String2ListString(string value, string splitter = ";")
        {
            List<string> list = new List<string>();

            if (string.IsNullOrEmpty(value) || splitter == null)
            {
                return list;
            }

            string[] strArray = value.Split(splitter[0]);

            for (int i = 0; i < strArray.Length; i++)
            {
                list.Add(strArray[i]);
            }

            return list;
        }

        public static string StringClone(string value)
        {
            if (null == value || value.Length <= 0)
            {
                return string.Empty;
            }

            return string.Copy(value);
        }

        public static int String2Int(string value)
        {
            int ret = 0;
            int.TryParse(value, out ret);

            return ret;
        }


        public static bool String2Bool(string value)
        {
            bool ret = false;
            if (String2Int(value) > 0)
            {
                return true;
            }
            else
            {
                bool.TryParse(value, out ret);
            }
            return ret;
        }

        public static long String2Int64(string value)
        {
            Int64 ret = 0;
            Int64.TryParse(value, out ret);

            return ret;
        }

        public static float String2Float(string value)
        {
            float ret = 0;
            float.TryParse(value, out ret);

            return ret;
        }

        public static double String2Double(string value)
        {
            double ret = 0;
            double.TryParse(value, out ret);
            return ret;
        }

        public static Vector2 String2Vector2(string pos)
        {
            return String2Vector2(pos, ',');
        }

        public static Vector2 String2Vector2(string pos, char split)
        {
            if (string.IsNullOrEmpty(pos))
            {
                return Vector2.zero;
            }

            char[] splits = new char[1] { split };
            string[] str = pos.Split(splits);

            float x = str.Length > 0 ? String2Float(str[0]) : 0f;
            float y = str.Length > 1 ? String2Float(str[1]) : 0f;

            Vector2 ret = new Vector2(x, y);

            return ret;
        }

        public static Vector3 String2Vector3(string pos)
        {
            return String2Vector3(pos, ',');
        }

        public static Vector3 String2Vector3(string pos, char split)
        {
            if (string.IsNullOrEmpty(pos))
            {
                return Vector3.zero;
            }

            char[] splits = new char[1] { split };
            string[] str = pos.Split(splits);

            float x = str.Length > 0 ? String2Float(str[0]) : 0f;
            float y = str.Length > 1 ? String2Float(str[1]) : 0f;
            float z = str.Length > 2 ? String2Float(str[2]) : 0f;

            Vector3 ret = new Vector3(x, y, z);

            return ret;
        }

        public static Color String2Color(string value, char split)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Color.white;
            }

            char[] splits = new char[1] { split };
            string[] str = value.Split(splits);

            float r = str.Length > 0 ? String2Int(str[0]) / 255.0f : 0f;
            float g = str.Length > 1 ? String2Int(str[1]) / 255.0f : 0f;
            float b = str.Length > 2 ? String2Int(str[2]) / 255.0f : 0f;
            float a = str.Length > 3 ? String2Int(str[3]) / 255.0f : 1f;

            Color ret = new Color(r, g, b, a);

            return ret;
        }

        public static Color String2ColorHex(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Color.white;
            }

            int length = value.Length;
            int strCount = length / 2;
            if (length % 2 != 0)
            {
                ++strCount;
            }

            string[] str = new string[strCount];
            for (int i = 0; i < strCount; ++i)
            {
                int leftLength = Mathf.Min(2, length - i * 2);
                str[i] = value.Substring(i * 2, leftLength);
            }

            try
            {
                float r = str.Length > 0 ? Convert.ToInt16(str[0], 16) / 255.0f : 0f;
                float g = str.Length > 1 ? Convert.ToInt16(str[1], 16) / 255.0f : 0f;
                float b = str.Length > 2 ? Convert.ToInt16(str[2], 16) / 255.0f : 0f;
                float a = str.Length > 3 ? Convert.ToInt16(str[3], 16) / 255.0f : 1f;

                Color ret = new Color(r, g, b, a);

                return ret;
            }
            catch (Exception e)
            {
                Log.e(e);
            }

            return Color.white;
        }

        // public static string ListInt2String(List<int> list, char split = ';')
        // {
        //     if (null == list || list.Count <= 0)
        //     {
        //         return "";
        //     }

        //     StringBuilder data = new StringBuilder();

        //     for (int i = 0; i < list.Count; ++i)
        //     {
        //         data.Append(list[i]);

        //         if (i != list.Count - 1)
        //         {
        //             data.Append(split);
        //         }
        //     }

        //     return data.ToString();
        // }

        public static int[] String2IntArray(string data, string split = "-")
        {
            string[] strArray = data.Split(split[0]);

            int[] ret = new int[strArray.Length];

            for (int i = 0; i < strArray.Length; ++i)
            {
                ret[i] = StringHelper.String2Int(strArray[i]);
            }

            return ret;
        }
    }

}