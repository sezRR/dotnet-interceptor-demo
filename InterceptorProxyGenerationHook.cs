using Castle.DynamicProxy;
using System.Reflection;

namespace InterceptorDemo;

public class LogInterceptorProxyGenerationHook : IProxyGenerationHook
{
    public void MethodsInspected()
    {
    }

    public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
    {
    }

    public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
    {
        var property = type.GetProperty(methodInfo.Name[4..]);

        if (property == null) return false;

        return methodInfo.Name.StartsWith("get_") 
            && property.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(LogAttribute));
    }
}
