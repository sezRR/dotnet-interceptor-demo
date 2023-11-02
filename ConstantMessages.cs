using InterceptorDemo.Resources;

namespace InterceptorDemo;

public class ConstantMessages
{
    [Log("Name", typeof(Locals))]
    public virtual required string Name { get; set; }

    [Log("Name", typeof(Locals), "fr-FR")]
    public virtual required string NameInFrench { get; set; }
}