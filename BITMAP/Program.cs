using System;
using System.Collections.Generic;
using System.Text;


public static class Problem
{
    private static readonly Tuple<int, int>[] nightbor = new[]
    {
        Tuple.Create(-1, 0), Tuple.Create(1, 0),
        Tuple.Create(0, -1), Tuple.Create(0, 1),
    };

    public static int?[,] Solve(int Wiersz, int Kolumna, string[] ZerowyWiersz)
    {
        int?[,] Dystans = new int?[Wiersz, Kolumna];
        var Fala = new Queue<Tuple<int, int>>();


        for (int r = 0; r < Wiersz; ++r)
        {
            for (int c = 0; c < Kolumna; ++c)
            {
                if (ZerowyWiersz[r][c] == '1')
                {
                    Dystans[r, c] = 0;
                    Fala.Enqueue(Tuple.Create(r, c));
                }
            }
        }

        while (Fala.Count > 0)
        {
            int rozmiar = Fala.Count;
            for (int i = 0; i < rozmiar; ++i)
            {
                Tuple<int, int> ElFali = Fala.Dequeue();
                int WierszFali = ElFali.Item1;
                int KolumnaFali = ElFali.Item2;
                int Element
                    = Dystans[WierszFali, KolumnaFali].Value + 1;

                foreach (var zmiana in nightbor)
                {
                    int Wiersz2 = WierszFali + zmiana.Item1;
                    int Kolumna2 = KolumnaFali + zmiana.Item2;

                    if (Wiersz2 >= 0 && Wiersz2 < Wiersz
                        && Kolumna2 >= 0 && Kolumna2 < Kolumna
                        && !Dystans[Wiersz2, Kolumna2].HasValue)
                    {
                        Dystans[Wiersz2, Kolumna2]
                            = Element;
                        Fala.Enqueue(Tuple.Create(Wiersz2, Kolumna2));
                    }
                }
            }
        }

        return Dystans;
    }
}

public static class Program
{
    private static void Main()
    {
        int Test = int.Parse(Console.ReadLine());
        while (Test-- > 0)
        {
            int[] linia = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int ZliczWiersze = linia[0];
            int ZliczKolumny = linia[1];

            string[] ZeroweWiersze = new string[ZliczWiersze];
            for (int r = 0; r < ZliczWiersze; ++r)
            {
                ZeroweWiersze[r] = Console.ReadLine();
            }

            var output = new StringBuilder();
            int?[,] Dystans = Problem.Solve(ZliczWiersze, ZliczKolumny, ZeroweWiersze);
            for (int r = 0; r < ZliczWiersze; ++r)
            {
                output.Append(Dystans[r, 0]);
                for (int c = 1; c < ZliczKolumny; ++c)
                {
                    output.Append($" {Dystans[r, c]}");
                }
                output.AppendLine();
            }

            Console.Write(output);
            Console.ReadLine();
        }
    }
}