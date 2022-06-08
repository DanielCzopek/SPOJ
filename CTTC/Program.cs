
using System;

public static class Problem
{
	public static readonly int me = 100025;

	public static int n;
	public static int m;
	public static int q;
	public static int x;
	public static int y;
	public static char type;
	public static int[] par = new int[me];
	public static int[] sz = new int[me];

	public static int Find(int x)
	{
		return x == par[x] ? x : par[x] = Find(par[x]);
	}
	public static void Union(int x, int y)
	{
		int r1 = Find(x);
		int r2 = Find(y);
		if (r1 == r2)
		{
			return;
		}
		if (sz[r1] + sz[r2] > m)
		{
			return;
		}
		Random rnd = new Random();
		int rndnext = rnd.Next(1);

		if (rndnext != 0)
		{
			par[r1] = r2;
			sz[r2] += sz[r1];
		}
		else
		{
			par[r2] = r1;
			sz[r1] += sz[r2];
		}
	}

	internal static void Main()
	{
		//ios_base::sync_with_stdio(0);
		//cin.tie(0);

		string tempVar = Console.ReadLine();
		if (tempVar != null)
		{
			n = int.Parse(tempVar);
		}
		string tempVar2 = Console.ReadLine();
		if (tempVar2 != null)
		{
			m = int.Parse(tempVar2);
		}
		string tempVar3 = Console.ReadLine();
		if (tempVar3 != null)
		{
			q = int.Parse(tempVar3);
		}
		for (int i = 1; i <= n; i++)
		{
			par[i] = i;
			sz[i] = 1;
		}
		while ((q--) != 0)
		{
			string tempVar4 = Console.ReadLine();
			if (tempVar4 != null)
			{
				type = tempVar4[0];
			}
			if (type == 'S')
			{
				string tempVar5 = Console.ReadLine();
				if (tempVar5 != null)
				{
					x = int.Parse(tempVar5);
				}
				Console.Write("{0:D}\n", sz[Find(x)]);
			}
			else if (type == 'E')
			{
				string tempVar6 = Console.ReadLine();
				if (tempVar6 != null)
				{
					x = int.Parse(tempVar6);
				}
				string tempVar7 = Console.ReadLine();
				if (tempVar7 != null)
				{
					y = int.Parse(tempVar7);
				}
				Console.Write(Find(x) == Find(y) ? "Yes\n" : "No\n");
			}
			else
			{
				string tempVar8 = Console.ReadLine();
				if (tempVar8 != null)
				{
					x = int.Parse(tempVar8);
				}
				string tempVar9 = Console.ReadLine();
				if (tempVar9 != null)
				{
					y = int.Parse(tempVar9);
				}
				Union(x, y);
			}
		}

	