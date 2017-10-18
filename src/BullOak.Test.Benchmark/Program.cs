﻿namespace BullOak.Test.Benchmark
{
    using System.Collections.Generic;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Running;

    class Program
    {
        static void Main(string[] args)
        {
            var b = new SaveAggregateBenchmark();
            var benchmarks = new List<Benchmark>();

            benchmarks.AddRange(BenchmarkConverter.TypeToBenchmarks(typeof(SaveAggregateBenchmark)));
            benchmarks.AddRange(BenchmarkConverter.TypeToBenchmarks(typeof(LoadAggregateOneEventNoChildsBenchmark)));
            benchmarks.AddRange(BenchmarkConverter.TypeToBenchmarks(typeof(SaveChildEntityBenchmark)));
            benchmarks.AddRange(BenchmarkConverter.TypeToBenchmarks(typeof(LoadAggregateWithChildEntitiesBenchmark)));
            benchmarks.AddRange(BenchmarkConverter.TypeToBenchmarks(typeof(EditChildEntitiesBenchmark)));

            var summary = BenchmarkRunner.Run(benchmarks.ToArray(), null);
        }
    }
}