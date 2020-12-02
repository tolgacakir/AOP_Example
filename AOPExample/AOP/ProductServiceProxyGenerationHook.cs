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
            //var assembly = Assembly.LoadFrom(type.Assembly.Location);
            //var method = assembly
            //    .GetTypes()
            //    .FirstOrDefault(t => t.Name == "ProductService") //TODO: asıl sorun type olarak gelenin interface olması. gelen type'daki methodların üzerinde attribute yok!!!!
            //    .GetMethods()
            //    .FirstOrDefault(m => m.Name == methodInfo.Name);

            //var result = method
            //    .CustomAttributes
            //    .Any(a => a.AttributeType == typeof(UseInterceptorAttribute));
            //return result;
            return methodInfo
                .CustomAttributes
                .Any(a => a.AttributeType == typeof(UseInterceptorAttribute));
        }
    }
}
