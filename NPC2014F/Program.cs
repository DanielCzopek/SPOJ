using System;

public static class Globals
{
	public static readonly int me = 100025;
	public static readonly int ALPHA = 125;

	public static int n;
	public static int m;
	public static int[] cnt = new int[ALPHA];
	public static int[] cur = new int[ALPHA];
	public static char[] s = new char[me];

	public static bool CanRemove(int pos)
	{
		cur[s[pos]]--;
		bool ok = true;
		for (int i = 'a'; i <= 'z' && ok; i++)
		{
			ok &= cur[i] >= cnt[i];
		}
		cur[s[pos]]++;
		return ok;
	}
	public static bool Good()
	{
		for (int i = 'a'; i <= 'z'; i++)
		{
			if (cur[i] < cnt[i])
			{
				return false;
			}
		}
		return true;
	}

	internal static void Main(string[] args)
	{
		

		string tempVar = Console.ReadLine();
		if (tempVar != null)
		{
			n = int.Parse(tempVar);
		}
		string tempVar2 = Console.ReadLine();
		if (tempVar2 != null)
		{
            s.Substring(1) = int.Parse(tempVar2);
		}
		string tempVar3 = Console.ReadLine();
		if (tempVar3 != null)
		{
			m = int.Parse(tempVar3);
		}
		while ((m--) != 0)
		{
			int x;
			char ch;
			string tempVar4 = Console.ReadLine();
			if (tempVar4 != null)
			{
				x = int.Parse(tempVar4);
			}
			string tempVar5 = Console.ReadLine();
			if (tempVar5 != null)
			{
				ch = tempVar5[0];
			}
			x = cnt[ch].;
		}
		int ans = n + 1;
		int ptr = 1;
		for (int i = 1; i <= n; i++)
		{
			cur[s[i]]++;
			while (ptr <= n && CanRemove(ptr))
			{
				cur[s[ptr]]--;
				ptr++;
			}
			if (Good())
			{
				ans = Math.Min(ans, i - ptr + 1);
			}
		}
		if (ans > n)
		{
			Console.Write("Andy rapopo\n");
		}
		else
		{
			Console.Write("{0:D}\n", ans);
		}

	}
}

