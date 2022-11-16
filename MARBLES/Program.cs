using System;
using System.Numerics;


public static class Problem
{

    public static BigInteger Solve(int cnt, int colorcnt)
        => NumberOfCombinations(cnt - 1, colorcnt - 1);


    private static BigInteger NumberOfCombinations(int n, int k)
    {
        k = Math.Min(k, n - k);
        if (k == 0)
            return 1;

        BigInteger result = n;
        for (int dm = 2; dm <= k; ++dm)
        {

            result *= n - dm + 1;
            result /= dm;
        }

        return result;
    }
}

public static class Program
{
    private static void Main()
    {
        int test = int.Parse(Console.ReadLine());
        while (test-- > 0)
        {
            int[] line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine(
                Problem.Solve(line[0], line[1]));
        }
    }
}
