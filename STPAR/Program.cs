using System;
using System.Collections.Generic;

namespace STPAR
{
    class Program
    {
        static void Main(string[] args)
        {
            int Cnt;
            while ((Cnt = int.Parse(Console.ReadLine())) != 0)
            {
                int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                Console.WriteLine(Problem.Rozwiazanie(arr) ? "yes" : "no");
            }
        }
    }

    public static class Problem
    {
        public static bool Rozwiazanie(int[] arr)
        {
            var pomoc = new Stack<int>();
            int next = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                while (pomoc.Count > 0 && pomoc.Peek() == next)
                {
                    pomoc.Pop();
                    next++;
                }

                int con = arr[i];
                if (con == next)
                {
                    next++;
                }
                else if (pomoc.Count == 0 || con < pomoc.Peek())
                {
                    pomoc.Push(con);
                }
                else return false;
            }
            return true;
        }
    }
}