/************************
	FileName:/GFrameWork/Scripts/Engine/UI/MVVM/Proxy/Targets/TargetProxyFactory.cs
	CreateAuthor:neo.xu
	CreateTime:3/3/2021 3:21:14 PM
	Tip:3/3/2021 3:21:14 PM
************************/


using System;


namespace GFrame
{
    public class TargetProxyFactory : ITargetProxyFactory
    {
        public ITargetProxy CreateProxy(object target, BindingDescription description)
        {
            try
            {
                ITargetProxy proxy = null;
                if (TryCreateProxy(target, description, out proxy))
                    return proxy;

                throw new NotSupportedException("Not found available proxy factory.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected virtual bool TryCreateProxy(object target, BindingDescription description, out ITargetProxy proxy)
        {
            proxy = null;
            return false;
        }
    }

}