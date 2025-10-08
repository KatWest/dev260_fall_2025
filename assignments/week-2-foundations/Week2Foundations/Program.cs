// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // RunArrayDemo();
        // RunListDemo();
        // RunStackDemo();
        // RunQueueDemo();
        // RunDictionaryDemo();
        // RunHashSetDemo();
        RunBenchmarks();
    }

    static void RunArrayDemo()
    {
        Console.WriteLine("=== Arrays ===");
        int[] temps = new int[10];
        temps[0] = 68; temps[1] = 67; temps[2] = 70;
        int searchValue = 71;

        Console.WriteLine($"Index 2: {temps[2]}");

        Console.WriteLine($"Search for {searchValue}: Index of {Array.FindIndex(temps, num => num == searchValue)}");
    }

    static void RunListDemo()
    {
        Console.WriteLine("=== List<T> ===");
        var nums = new List<int> { 1, 2, 3, 4, 5 };
        nums.Insert(2, 99); // O(n)
        Console.WriteLine(string.Join(", ", nums));
        nums.Remove(99);
        Console.WriteLine($"Count after remove: {nums.Count}\n");
    }
    static void RunStackDemo()
    {
        Console.WriteLine("=== Stack<T> ===");
        var stack = new Stack<string>();
        stack.Push("https://www.youtube.com/@minecraft");
        stack.Push("https://www.youtube.com/@EVNautilus");
        stack.Push("https://www.youtube.com/@CinemaWins");
        Console.WriteLine($"Peek: {stack.Peek()}");

        while (stack.Count > 0)
            Console.WriteLine($"Pop: {stack.Pop()}");
    }

    static void RunQueueDemo()
    {
        Console.WriteLine("=== Queue<T> ===");
        var q = new Queue<int>();
        q.Enqueue(10); q.Enqueue(20); q.Enqueue(42);
        Console.WriteLine($"Front: {q.Peek()}");

        while (q.Count > 0)
            Console.WriteLine($"Dequeue: {q.Dequeue()}");
    }
    static void RunDictionaryDemo()
    {
        Console.WriteLine("=== Dictionary<TKey, TValue> ===");
        var inventory = new Dictionary<string, int>
        {
            ["SKU-123"] = 50,
            ["SKU-456"] = 12,
            ["SKU-042"] = 42
        };
        inventory["SKU-123"] += 5;
        if (inventory.TryGetValue("SKU-999", out var qty))
            Console.WriteLine(qty);
        else
            Console.WriteLine("SKU-999 not found");
        foreach (var kv in inventory)
            Console.WriteLine($"{kv.Key} -> {kv.Value}");
    }
    static void RunHashSetDemo()
    {
        Console.WriteLine("=== HashSet<T> ===");
        var set = new HashSet<int> { 1, 2, 3 };
        Console.WriteLine($"Add 2 again? {set.Add(2)}");
        var bSet = new HashSet<int> { 3, 4, 5 };
        set.UnionWith(bSet);
        Console.WriteLine($"Union size: {set.Count}");
    }

    static void RunBenchmarks()
    {
        Console.WriteLine("=== Mini Benchmark ===");
        var array = new int[4];
        array[0] = 1000; array[1] = 10000; array[2] = 100000; array[3] = 250000;

        foreach (int j in array)
        {
            var list = new List<int>();
            var dict = new Dictionary<int, bool>();
            var hash = new HashSet<int>();

            for (int i = 0; i < j - 1; i++)
            { list.Add(i); dict[i] = true; hash.Add(i); }

            Console.WriteLine($"\nN={j}");

            var sw = Stopwatch.StartNew();
            
            bool listContains = list.Contains(j - 1);
            sw.Stop();
            Console.WriteLine($"List.Contains(N-1): {sw.Elapsed.TotalMilliseconds} ms");
            sw.Restart();

            bool hashContains = hash.Contains(j);
            sw.Stop();
            Console.WriteLine($"HashSet.Contains: {sw.Elapsed.TotalMilliseconds} ms");
            sw.Restart();

            bool dictContains = dict.ContainsKey(j);
            sw.Stop();
            Console.WriteLine($"Dict.ContainsKey: {sw.Elapsed.TotalMilliseconds} ms");
            sw.Restart();


            listContains = list.Contains(-1);
            sw.Stop();
            Console.WriteLine($"List.Contains(-1): {sw.Elapsed.TotalMilliseconds} ms");
            sw.Restart();

            hashContains = hash.Contains(-1);
            sw.Stop();
            Console.WriteLine($"HashSet.Contains (-1): {sw.Elapsed.TotalMilliseconds} ms");
            sw.Restart();

            dictContains = dict.ContainsKey(-1);
            sw.Stop();
            Console.WriteLine($"Dict.ContainsKey (-1): {sw.Elapsed.TotalMilliseconds} ms");
            
        }
    }
}