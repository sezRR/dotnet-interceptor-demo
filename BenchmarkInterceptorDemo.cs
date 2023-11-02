using BenchmarkDotNet.Attributes;

namespace InterceptorDemo;

public class BenchmarkInterceptorDemo
{
    [Benchmark]
    public void WriteConstantMessagesToConsole()
    {
        var constantMessages = new InterceptorDemoDependencyResolver().GetService<ConstantMessages>();

        Console.WriteLine(constantMessages.Name);
        Console.WriteLine(constantMessages.NameInFrench);
    }
}
