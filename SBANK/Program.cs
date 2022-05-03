using System.Text;

class Problem
{
    public static void Solve(int Count, StringBuilder output)
    {
        var wystapienia = new SortedDictionary<string, int>();

        while (Count-- > 0)
        {
            string account = Console.ReadLine();

            int licznik;
            if (wystapienia.TryGetValue(account, out licznik))
                wystapienia[account] = licznik + 1;
            else
                wystapienia[account] = 1;
        }

        Console.ReadLine();

        foreach (var wystapienia2 in wystapienia)
        {
            output.AppendLine($"{wystapienia2.Key} {wystapienia2.Value}");
        }
        output.AppendLine();
    }

}

class Program
{
    static void Main()
    {
        int test = int.Parse(Console.ReadLine());
        var output = new StringBuilder();
        while (test > 0)
        {
            Problem.Solve(Count: int.Parse(Console.ReadLine()), output);

        }

        Console.WriteLine(output);
    }
}