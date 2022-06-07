using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Problem
{
    private const int Limit = 1000000;
    private static readonly Rozmiar Factor;

    static Problem()
    {
        Factor = new Rozmiar(Limit);
    }
    public static int Rozwiązanie(int n)
    {
        int[] distinct = Factor.GetDistinctPrimeFactors(n).ToArray();

        double dbl = n;
        foreach (int Factor1 in distinct)
        {
            dbl *= (1 - 1 / (double)Factor1);
        }

        return (int)Math.Round(dbl);
    }
}

public sealed class Rozmiar
{
   
    private readonly IReadOnlyList<int?> list;

    public Rozmiar(int limit)
    {
        Limit = limit;

        int?[] List = new int?[Limit + 1];
        List[0] = 0;
        List[1] = 1;

        for (int n = 2; n * n <= Limit; ++n)
        {
            if (!List[n].HasValue)
            {
                for (int next = n * n;
                    next <= Limit;
                    next += n)
                {
                    List[next] = n;
                }
            }
        }
        list = Array.AsReadOnly(List);
    }

    public int Limit { get; }

    public bool IsPrime(int n)
        => !list[n].HasValue;

    public IEnumerable<int> GetDistinctPrimeFactors(int n)
    {
        while (n > 1)
        {
            int prime = list[n] ?? n;
            yield return prime;

            while (n % prime == 0)
            {
                n /= prime;
            }
        }
    }
}

public static class Program
{
    private static void Main()
    {
        var output = new StringBuilder();
        int test = int.Parse(Console.ReadLine());
        while (test-- > 0)
        {
            int n = int.Parse(Console.ReadLine());
            output.Append(
                Problem.Rozwiązanie(n));
            output.AppendLine();
        }

        Console.Write(output);
    }
}