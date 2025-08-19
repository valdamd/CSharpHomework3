// <copyright file="EuclideanGcd.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task3;
using System.Diagnostics;

internal static class EuclideanGcd
{
    public static int Calculate(int a, int b)
    {
        return Gcd(a, b);
    }

    public static int Calculate(int a, int b, out TimeSpan elapsed)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = Gcd(a, b);
        stopwatch.Stop();
        elapsed = stopwatch.Elapsed;
        return result;
    }

    public static int Calculate(int a, int b, int c, out TimeSpan elapsed)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = Gcd(Gcd(a, b), c);

        stopwatch.Stop();
        elapsed = stopwatch.Elapsed;

        return result;
    }

    public static int Calculate(params int[] numbers)
    {
        if (numbers.Length == 0)
        {
            throw new ArgumentException("At least one number must be provided.", paramName: nameof(numbers));
        }

        var result = numbers[0];

        for (var i = 1; i < numbers.Length; i++)
        {
            result = Gcd(result, numbers[i]);
        }

        return result;
    }

    public static int Calculate(out TimeSpan elapsed, params int[] numbers)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = Calculate(numbers);
        stopwatch.Stop();
        elapsed = stopwatch.Elapsed;
        return result;
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return Math.Abs(a);
    }
}
