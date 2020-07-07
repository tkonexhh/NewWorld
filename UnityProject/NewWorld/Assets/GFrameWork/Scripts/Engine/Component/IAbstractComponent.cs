/************************
	FileName:/GFrameWork/Scripts/Engine/Component/IAbs.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 1:58:52 PM
	Tip:7/7/2020 1:58:52 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public interface IAbstractComponent
    {
        void Awake();
        void Start();
        void Destory();
    }


    public class AbstractComponent : IAbstractComponent
    {
        public void Awake() { OnAwake(); }
        public void Start() { OnStart(); }
        public void Destory() { OnDestory(); }

        protected virtual void OnAwake() { }
        protected virtual void OnStart() { }
        protected virtual void OnDestory() { }
    }

}