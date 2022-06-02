using System;
using System.Collections.Generic;

public static class Problem
{
    private const int limit = 100;
    private static readonly IReadOnlyList<int> _kąty;
   

    static Problem()
    {
        int[] kąty = new int[limit + 1];
        kąty[0] = 0;
        kąty[1] = 1;
        kąty[2] = 5;

        for (int i = 3; i <= limit; ++i)
        {
        
            kąty[i] += 1;

            kąty[i] += 4 * (i - 1);

            
            kąty[i] += 4 * SumFromOneUntil(i - 2);

           
            kąty[i] += kąty[i - 2];
        }

        _kąty = kąty; 
    }

    private static int SumFromOneUntil(int i)
        => i * (i + 1) / 2;
    public static int Solve(int i) => _kąty[n];
    
}

public static class Program
{
    private static void Main()
    {
        int i;
        while ((i = int.Parse(Console.ReadLine())) != 0)
        {
            Console.WriteLine(Problem.Solve(i));
        }
    }
}