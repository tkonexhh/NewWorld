/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Proxy/Source/SourceProxyFactory.cs
	CreateAuthor:neo.xu
	CreateTime:3/3/2021 2:32:07 PM
	Tip:3/3/2021 2:32:07 PM
************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class SourceProxyFactory : ISourceProxyFactory
    {
        public ISourceProxy CreateProxy(object source, SourceDescription description)
        {
            try
            {
                ISourceProxy proxy = null;
                if (TryCreateProxy(source, description, out proxy))
                    return proxy;

                throw new NotSupportedException("Not found available proxy factory");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool TryCreateProxy(object source, SourceDescription description, out ISourceProxy proxy)
        {
            proxy = null;
            return false;
        }
    }

}