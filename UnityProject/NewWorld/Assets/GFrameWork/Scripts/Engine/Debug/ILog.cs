/************************
	FileName:/GFrameWork/Scripts/Engine/Debug/ILog.cs
	CreateAuthor:neo.xu
	CreateTime:3/1/2021 2:13:34 PM
	Tip:3/1/2021 2:13:34 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GFrame
{
    public interface ILog
    {
        void i(object msg);
        void i(string msg, params object[] args);
        void e(object msg);
        void e(Exception e);
        void e(string msg, params object[] args);
        void w(object msg);
        void w(string msg, params object[] args);
    }

    public abstract class AbstractLog : ILog
    {
        public void i(object msg) { }
        public void i(string msg, params object[] args) { }
        public void e(object msg) { }
        public void e(Exception e) { }
        public void e(string msg, params object[] args) { }
        public void w(object msg) { }
        public void w(string msg, params object[] args) { }
    }

}