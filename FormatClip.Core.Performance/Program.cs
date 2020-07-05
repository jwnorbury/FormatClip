using BenchmarkDotNet.Running;
using System;

namespace FormatClip.Core.Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = BenchmarkRunner.Run<XmlPerformance>();
        }
    }
}
