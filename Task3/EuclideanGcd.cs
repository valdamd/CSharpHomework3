using System.Diagnostics;
namespace Task3;
public static class EuclideanGcd
{
    public static int Calculate(int a, int b)
    {
        return Gcd(a, b);
    }
    public static int Calculate(int a, int b, out TimeSpan elapsed)
    {
        var stopwatch = Stopwatch.StartNew();
        int result = Gcd(a, b);
        stopwatch.Stop();
        elapsed = stopwatch.Elapsed;
        return result;
    }
    public static int Calculate(int a, int b, int c, out TimeSpan elapsed)
    {
        var stopwatch = Stopwatch.StartNew();
        int result = Gcd(Gcd(a, b), c);
        stopwatch.Stop();
        elapsed = stopwatch.Elapsed;
        return result;
    }
    public static int Calculate(params int[] numbers)
    {
        if (numbers.Length == 0)
            throw new ArgumentException("At least one number must be provided.");

        int result = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            result = Gcd(result, numbers[i]);
        }
        return result;
    }
    public static int Calculate(out TimeSpan elapsed, params int[] numbers)
    {
        var stopwatch = Stopwatch.StartNew();
        int result = Calculate(numbers);
        stopwatch.Stop();
        elapsed = stopwatch.Elapsed;
        return result;
    }
    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return Math.Abs(a);
    }
}