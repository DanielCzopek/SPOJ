using System;
using System.Collections.Generic;

public static class Problem
{
    private const int limit = 100;
   

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

      
    }

    private static int SumFromOneUntil(int n)
        => n * (n + 1) / 2;

    
}

public static class Program
{
    private static void Main()
    {
    }
}