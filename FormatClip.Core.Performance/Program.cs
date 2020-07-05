using BenchmarkDotNet.Running;

namespace FormatClip.Core.Performance
{
    class Program
    {
        static void Main()
        {
            _ = BenchmarkRunner.Run<XmlPerformance>();
        }
    }
}
