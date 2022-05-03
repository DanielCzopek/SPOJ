using System;

public static class Problem
{
    public static string Solve(string str)
    {
        if (str.Length == 1)
            return str;

        string str1 = str.Substring(
            startIndex: 1,
            length: str2Length(str, startIndex: 1));

        string str2 = str.Substring(
            startIndex: 1 + str1.Length + 1,
            length: str.Length - (1 + str1.Length + 1) - 1);

        char wzkaznik = str[1 + str1.Length];

        return Solve(str1) + Solve(str2) + wzkaznik;
    }

    private static int str2Length(string str, int startIndex)
    {
        int Index = startIndex;
        int nawiasy = 0;
        do
        {
            if (str[Index] == '(')
                ++nawiasy;
            else if (str[Index] == ')')
                --nawiasy;
            ++Index;
        } while (nawiasy != 0);

        return Index - startIndex;
    }
}

public static class Program
{
    private static void Main()
    {
        int Test = int.Parse(Console.ReadLine());
        while (Test-- > 0)
        {
            Console.WriteLine(
                Problem.Solve(Console.ReadLine()));
        }
    }
}