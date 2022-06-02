using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program
{
    class Problem
    {
        static void Main(string[] args)
        {

            var wynik = new StringBuilder();
            string[] kolumna1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(kolumna1[0]);
            long c = long.Parse(kolumna1[1]);
            List<long> liczby = new List<long>(n);
            Dictionary<string, long> ilość = new Dictionary<string, long>();
            string[] kolumna2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


            foreach (string liczba in kolumna2)
            {
                if (liczby.Contains(long.Parse(liczba)))
                    ilość[liczba]++;
                else
                    ilość[liczba] = 1;

                liczby.Add(long.Parse(liczba));
            }

            var zmienna = ilość.OrderByDescending(x => x.Value).Select(x => x.Key);

            foreach (var wartość in zmienna)
            {
                ilość.TryGetValue(wartość, out long Wartość);

                for (int i = 0; i < Wartość; i++)
                    wynik.Append($"{wartość} ");
            }
            Console.WriteLine(wynik);
        }
    }
}