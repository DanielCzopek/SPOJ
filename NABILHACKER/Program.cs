using System;
using System.Collections.Generic;

public class Problem
{
    public static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        string[] list = new string[a];
        for (int i = 0; i < a; i++)
        {
            string text = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            Stack<char> stack_2 = new Stack<char>();
            for (int w = 0; w < text.Length; w++)
            {
                switch (text[w])
                {
                    case '-':
                        if (stack.Count != 0)
                            stack.Pop();
                        break;
                    case '<':
                        if (stack.Count != 0)
                            stack_2.Push(stack.Pop());
                        break;
                    case '>':
                        if (stack_2.Count != 0)
                            stack.Push(stack_2.Pop());
                        break;
                    default:
                        stack.Push(text[w]);
                        break;
                }
            }
            while (stack.Count != 0) stack_2.Push(stack.Pop());
            list[i] = new String(stack_2.ToArray());
        }
        for (int x = 0; x < a; x++)
            Console.WriteLine(list[x]);
    }
}
