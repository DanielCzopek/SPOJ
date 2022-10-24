using System;
using System.Collections.Generic;

    static class Program
    {
    static void Main(string[] args)
    {
            string n = Console.ReadLine();
            int num = int.Parse(n);
            for (int i = 0; i < num; i++)
            {
                if (Solve.Test(Console.ReadLine()))
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }
    }
    public class Solve
    {
        private string Przyklad;
        private Tree DrzewoPrzykladow;
        char[] Zmiany = new char[26];
        int Licznik = 0;
        private char[] Operacje = new char[] { 'I', 'C', 'D', 'N', 'E' };
        private Solve(string przyklad)
        {
            this.Przyklad = przyklad;
        }
        public static bool Test(string przyklad)
        {
            Solve ex = new Solve(przyklad);
            int endIndex = 0;
            ex.GenerujZastapienie();
            ex.DrzewoPrzykladow = ex.AnulujZastapienie(0, out endIndex);
            return ex.WeryfikujKombinacje();
        }
        private bool WeryfikujKombinacje()
        {
            long limit = 1 << Licznik;
            for (int i = 0; i < limit; i++)
            {
                if (Sprawdz(i, DrzewoPrzykladow))
                    continue;
                return false;
            }
            return true;
        }
        private bool Sprawdz(int i, Tree t)
        {
            if (t.type == SymbolType.Variable)
            {
                return (i & (1 << (t.node - 'a'))) != 0;
            }
            else
            {
                if (t.node == 'N')
                    return !Sprawdz(i, t.left);
                if (t.node == 'C')
                    if (Sprawdz(i, t.left))
                        return Sprawdz(i, t.right);
                    else
                        return false;
                if (t.node == 'D')
                    if (!Sprawdz(i, t.left))
                        return Sprawdz(i, t.right);
                    else
                        return true;
                if (t.node == 'I')
                {
                    bool left = Sprawdz(i, t.left);
                    if (left)
                    {
                        return Sprawdz(i, t.right);
                    }
                    return true;
                }
                if (t.node == 'E')
                {
                    return Sprawdz(i, t.left) == Sprawdz(i, t.right);
                }
                return true;
            }
        }
        private Tree AnulujZastapienie(int startIndex, out int endIndex)
        {
            Tree t = new Tree();
            t.node = Przyklad[startIndex];
            endIndex = startIndex;
            t.type = SymbolType.Variable;
            SymbolType type = SprawdzKod(Przyklad[startIndex]);
            if (type == SymbolType.Operator)
            {
                t.type = SymbolType.Operator;
                if (Przyklad[startIndex] == 'N')
                {
                    t.left = AnulujZastapienie(startIndex + 1, out endIndex);
                }
                else
                {
                    t.left = AnulujZastapienie(startIndex + 1, out endIndex);
                    t.right = AnulujZastapienie(endIndex + 1, out endIndex);
                }
            }
            return t;
        }
        private SymbolType SprawdzKod(char ch)
        {
            foreach (char ch1 in this.Operacje)
            {
                if (ch1 == ch)
                    return SymbolType.Operator;
            }
            return SymbolType.Variable;
        }
        private void GenerujZastapienie()
        {
            char[] alternateExpressions = new char[Przyklad.Length];
            for (int i = 0; i < Przyklad.Length; i++)
            {
                if (SprawdzKod(Przyklad[i]) == SymbolType.Operator)
                {
                    alternateExpressions[i] = Przyklad[i];
                    continue;
                }
                if (Zmiany[Przyklad[i] - 'a'] != 0)
                    alternateExpressions[i] = Zmiany[Przyklad[i] - 'a'];
                else
                {
                    Zmiany[Przyklad[i] - 'a'] = (char)(Licznik + 'a');
                    alternateExpressions[i] = (char)(Licznik + 'a');
                    Licznik++;
                }
            }
            this.Przyklad = new string(alternateExpressions);
        }
        public enum SymbolType
        {
            Operator,
            Variable
        }
        public class Tree
        {
            public char node;
            public SymbolType type;
            public Tree left, right;
        }
    }
