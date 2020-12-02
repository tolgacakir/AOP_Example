using System;
using System.Collections.Generic;
using System.Text;

namespace AOPExample.AOP
{
    [System.AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    sealed class UseInterceptorAttribute : Attribute
    {
        public UseInterceptorAttribute() //TODO: Interceptor tipleri parametre olarak alınıp hangi interceptorlerin kullanılacağı seçilebilir ya da interceptor seçimi makalesine bakılabilir.
        {
        }
    }
}
