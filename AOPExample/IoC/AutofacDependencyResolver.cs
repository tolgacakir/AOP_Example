using AOPExample.AOP;
using AOPExample.BusinessLogic;
using AOPExample.Logging;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOPExample.IoC
{
    public class AutofacDependencyResolver
    {
        private readonly IContainer _container;
        public AutofacDependencyResolver()
        {
            _container = BuildContainer();
        }

        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            var logger = LoggerFactory.GetSerilogFileLogger();

            builder.Register(c => logger)
                .As<Serilog.ILogger>()
                .SingleInstance();



            var proxyGenerationOptions = new ProxyGenerationOptions(new ProductServiceProxyGenerationHook());

            builder.RegisterType<ProductService>()
                .As<IProductService>()
                .WithParameter("logger", logger)
                .EnableInterfaceInterceptors(proxyGenerationOptions)
                .InterceptedBy(typeof(LoggingInterceptor));
                //.InterceptedBy(typeof(ExceptionHandlingInterceptor));

            builder.Register(c => new LoggingInterceptor(logger));
            builder.Register(c => new ExceptionHandlingInterceptor(logger));
            


            return builder.Build();
        }

        public T GetService<T>()
            where T:class
        {
            var result = _container.TryResolve(out T serviceInstance);

            return serviceInstance ?? throw new Exception($"Could not found the service: {nameof(T)}");
        }
    }
}
