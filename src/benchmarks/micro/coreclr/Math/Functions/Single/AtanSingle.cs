﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace System.MathBenchmarks
{
    public partial class Single
    {
        // Tests MathF.Atan(float) over 5000 iterations for the domain -1, +1

        private const float atanDelta = 0.0004f;
        private const float atanExpectedResult = 0.841940999f;

        [Benchmark]
        public void Atan() => AtanTest();

        public static void AtanTest()
        {
            var result = 0.0f; var value = -1.0f;

            for (var iteration = 0; iteration < MathTests.Iterations; iteration++)
            {
                value += atanDelta;
                result += MathF.Atan(value);
            }

            var diff = MathF.Abs(atanExpectedResult - result);

            if (diff > MathTests.SingleEpsilon)
            {
                throw new Exception($"Expected Result {atanExpectedResult,10:g9}; Actual Result {result,10:g9}");
            }
        }
    }
}
