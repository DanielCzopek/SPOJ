using System;
using System.IO;
public static class Problem
{
	public static int[] arr = new int[100001];

	public static T minimum<T>(T a, T b) where T : IComparable<T>
	{
		return a.CompareTo(b) < 0 ? a : b;
	}

	public static void Main()
	{
		//Console.SetIn(new StringReader(Test1));
		int test = int.Parse(Console.ReadLine());

		while (test != 0)
		{
			var test1 = Console.ReadLine().Split(' ');
			int parse = int.Parse(test1[0]);
			int x = int.Parse(test1[1]);

			var test2 = Console.ReadLine().Split(' ');

			for (int i = 0; i < parse; ++i)
			{
				arr[i] = int.Parse(test2[i]);
			}

			int slow = 0;
			int fast = 0;
			int sum = 0;
			int res = 0;
			int sum_res = 0;

			while (fast < parse)
			{
				sum += arr[fast];
				++fast;

				while (sum > x && slow < parse)
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
			test--;
		}

	}
}

