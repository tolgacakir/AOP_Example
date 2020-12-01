using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace AOPExample.AOP
{
    public class ProductServiceProxyGenerationHook : IProxyGenerationHook
    {
        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            //return methodInfo.CustomAttributes.Any(a => a.GetType() == typeof(UseInterceptorAttribute));
            //return true;
            return methodInfo.CustomAttributes.Count() > 0;
        }
    }
}
