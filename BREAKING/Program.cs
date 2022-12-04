using System;
using static System.Net.Mime.MediaTypeNames;

public static class Globals
{
    public static void BitSeive(int[] output)
    {
        int[] flagArr = new int[DefineConstants.MAX >> 6];
        int i;
        int j;
        int k;

        for (i = 3; i < DefineConstants.LIM; i += 2)
        {
            if ((flagArr[i >> 6] & (1 << ((i >> 1) & 31))) == 0)
            {
                for (j = i * i, k = i << 1; j < DefineConstants.MAX; j += k)
                {
                    flagArr[j >> 6] |= 1 << ((j >> 1) & 31);
                }
            }
        }

        output[0] = 2;
        for (i = 3, j = 1; i < DefineConstants.MAX; i += 2)
        {
            if ((flagArr[i >> 6] & (1 << ((i >> 1) & 31))) == 0)
            {
                output[j++] = i;
            }
        }
    }


    internal static void Main()
    {
        int[] sieve = new int[78500];
        
        BitSeive(sieve);

        
        string tempVar = Console.ReadLine();
        int tests = int.Parse(tempVar);

        

        for (int i = 1; i <= tests; ++i)
        {
            
            string tempVar2 = Console.ReadLine();
            
            
               int num = int.Parse(tempVar2);
            

            Console.Write("Case {0:D}:", i);

            for (int idx = 0; idx < sieve.Length && num > 1; ++idx)
            {
                if (num % sieve[idx] == 0)
                {
                    while (num % sieve[idx] == 0)
                    {
                        num /= sieve[idx];
                    }

                    Console.Write(" {0:D}", sieve[idx]);
                }
            }

            Console.Write("\n");
        }

    }
}

internal static class DefineConstants
{
    public const int MAX = 1000033;
    public const int LIM = 1001;
}
