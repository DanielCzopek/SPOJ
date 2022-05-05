using System;
using System.IO;
public static class AliensAtTheTrain
{
	//	const string Test1 = @"1
	//5 100
	//20 15 30 80 100";

	public static int[] arr = new int[100001];

	public static T minimum<T>(T a, T b) where T : IComparable<T>
	{
		return a.CompareTo(b) < 0 ? a : b;
	}

	public static void Main()
	{
		//Console.SetIn(new StringReader(Test1));
		int tests = int.Parse(Console.ReadLine());

		while (tests != 0)
		{
			var test1 = Console.ReadLine().Split(' ');
			int p = int.Parse(test1[0]);
			int m = int.Parse(test1[1]);

			var test2 = Console.ReadLine().Split(' ');

			for (int i = 0; i < p; ++i)
			{
				arr[i] = int.Parse(test2[i]);
			}

			int slow = 0;
			int fast = 0;
			int sum = 0;
			int res = 0;
			int sum_res = 0;

			while (fast < p)
			{
				sum += arr[fast];
				++fast;

				while (sum > m && slow < p)
				{
					sum -= arr[slow];
					++slow;
				}

				if (res < fast - slow) // New best, update all
				{
					res = fast - slow;
					sum_res = sum;
				}
				else if (res == fast - slow) // Equal best, minimize sum
				{
					sum_res = minimum(sum_res, sum);
				}
			}

			Console.Write("{0:D} {1:D}\n", sum_res, res);
			tests--;
		}

	}
}

