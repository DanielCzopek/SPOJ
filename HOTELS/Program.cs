using System;

public static class Problem
{
    public static long Solve(int cnt, int costLimit, int[] cost)
    {
        int startIndex = 0, endIndex = 0;
        long totalcost = cost[0];
        long maxtotalcost = 0;

        while (true)
        {
            
            while (endIndex + 1 < cnt
                && totalcost + cost[endIndex + 1] <= costLimit)
            {
                totalcost += cost[++endIndex];
            }

           
            if (totalcost < costLimit)
            {
                maxtotalcost = Math.Max(maxtotalcost, totalcost);
            }
            else if (totalcost == costLimit)
                return costLimit; 

            if (endIndex + 1 == cnt)
                break;

            totalcost -= cost[startIndex++];
            if (startIndex > endIndex)
            {
                endIndex = startIndex;
                totalcost = cost[startIndex];
            }
        }

        return maxtotalcost;
    }
}

public static class Program
{
    private static void Main()
    {
        int[] test = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
        int hotelCount = test[0];
        int costLimit = test[1];

        int[] hotelCosts = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);

        Console.WriteLine(
            Problem.Solve(hotelCount, costLimit, hotelCosts));
    }
}