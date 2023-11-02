using Castle.DynamicProxy;
using System.Reflection;
using System.Resources;

namespace InterceptorDemo;

public class LogInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        PropertyInfo property = invocation.TargetType.GetProperty(invocation.Method.Name[4..])!;

        PropertyInfo propertyInfo = invocation.TargetType.GetProperty(invocation.Method.Name[4..])!;
        LogAttribute logAttribute = (propertyInfo.GetCustomAttributes(typeof(LogAttribute)).FirstOrDefault() as LogAttribute)!;

        property.SetValue
            (
                invocation.InvocationTarget,
                new ResourceManager
                (
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.Resources.{logAttribute.Resource.Name}",
                    logAttribute.Resource.Assembly
                )
                .GetString(logAttribute.ResourceName, logAttribute.CultureInfo)
            );

        invocation.Proceed();
    }
}