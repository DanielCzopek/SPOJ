using System;
using System.Collections.Generic;

class Problem
{

    private static string Input()
    {
        string inp = "";
        while (inp.Length == 0)
        {
            inp = Console.ReadLine().Trim();
        }
        return inp;
    }

    public static void BuildHeap(int[] heap)
    {
        for (int i = heap.Length / 2; i >= 0; i--)
        {
            Heapify(heap, i);
        }
    }

    public static void Heapify(int[] heap, int i)
    {
        int prawy = 2 * i + 2;
        int lewy = 2 * i + 1;
        int min = i;

        if (prawy < heap.Length && heap[prawy] < heap[min])
        {
            min = prawy;
        }

        if (lewy < heap.Length && heap[lewy] < heap[min])
        {
            min = lewy;
        }
        
        if (min != i)
        {
            int temp = heap[i];
            heap[i] = heap[min];
            heap[min] = temp;
            Heapify(heap, min);
        }
    }
    public static void Main()
    {
        int test = int.Parse(Input());
        List<string> output = new List<string>();
        for (int i = 0; i < test; i++)
        {
            string input = Input();
            int n = int.Parse(input);
            int[] heap = new int[n];
            for (int j = 0; j < n; j++)
            {
                input = Input();
                heap[j] = int.Parse(input);
            }
            BuildHeap(heap);
            input = Input();
            int m = int.Parse(input);
            for (int j = 0; j < m; j++)
            {
                string command = Input();
                if (command == "E")
                {
                    output.Add(heap[0].ToString());
                    heap[0] = heap[n - 1];
                    n--;
                    BuildHeap(heap);
                }
                else
                {
                    output.Add(string.Join(" ", heap));
                }
            }
        }
        Console.Write(string.Join("\n", output));
    }
}