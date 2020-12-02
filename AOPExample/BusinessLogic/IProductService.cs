using AOPExample.AOP;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOPExample.BusinessLogic
{
    //[Intercept(typeof(LoggingInterceptor))]
    public interface IProductService
    {
        [UseInterceptor]
        Product Get(string productNumber, string serialNumber);

        bool Create(string productNumber, string serialNumber);

        [UseInterceptor]
        Product AOP_Get(string productNumber, string serialNumber);

    }
}
