using AOPExample.AOP;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOPExample.BusinessLogic
{
    public class ProductService : IProductService
    {
        private readonly Serilog.ILogger _logger;
        public ProductService(Serilog.ILogger logger = null)
        {
            _logger = logger;
        }

        
        public Product AOP_Get(string productNumber, string serialNumber)
        {
            var m = GetType().GetMethod("AOP_Get");
            return null;

        }

        public bool Create(string productNumber, string serialNumber)
        {
            _logger.Warning("the process in the method!");
            return true;
        }


        public Product Get(string productNumber, string serialNumber)
        {
            return new Product
            {
                Id = 5,
                ProductNumber = "testPN",
                SerialNumber = "testSN"
            };
        }
    }
}
