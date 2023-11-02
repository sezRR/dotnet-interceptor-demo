using System.Globalization;

namespace InterceptorDemo;

[AttributeUsage(AttributeTargets.Property)]
public class LogAttribute : Attribute
{
    public string ResourceName { get; }
    public Type Resource { get; }
    public CultureInfo CultureInfo { get; } = CultureInfo.CurrentCulture;

    public LogAttribute(string resourceName, Type resource)
    {
        ResourceName = resourceName;
        Resource = resource;
    }

    public LogAttribute(string resourceName, Type resource, string cultureInfoString) : this(resourceName, resource)
    {
        CultureInfo = CultureInfo.GetCultureInfo(cultureInfoString);
    }
}