namespace InterceptorDemo;

class Program
{
    static void Main()
    {
        // BenchmarkRunner.Run<BenchmarkInterceptorDemo>(); // 138.9 ms

        BenchmarkInterceptorDemo demo = new();
        demo.WriteConstantMessagesToConsole();
    }
}