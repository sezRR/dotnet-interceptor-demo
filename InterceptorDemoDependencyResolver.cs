using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace InterceptorDemo;

public class InterceptorDemoDependencyResolver
{
    private readonly IContainer _container = RegisterContainer();

    private static IContainer RegisterContainer()
    {
        var proxyGenerationOptions = new ProxyGenerationOptions(new LogInterceptorProxyGenerationHook());

        var builder = new ContainerBuilder();
        builder.Register(_ => new LogInterceptor());

        builder.RegisterType<ConstantMessages>()
            .EnableClassInterceptors(proxyGenerationOptions)
            .InterceptedBy(typeof(LogInterceptor));

        return builder.Build();
    }

    public T GetService<T>() where T : class
    {
        _container.TryResolve(out T? serviceInstance);

        ArgumentNullException.ThrowIfNull(serviceInstance);

        return serviceInstance;
    }
}