using System;
using System.Collections.Concurrent;

namespace ConcurrentDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var stock = new ConcurrentDictionary<string, int>();

            bool success;

            success = stock.TryAdd("blue", 1);
            success = stock.TryAdd("red", 2);
            success = stock.TryAdd("green", 3);
            
            success = stock.TryUpdate("red", 3, 2);

            var updatedValue = stock.AddOrUpdate("red", 1, (key, oldValue) => oldValue + 1);

            var yellowValue = stock.GetOrAdd("yellow", 1);

            if (stock.TryGetValue("red", out int value))
            {
                Console.WriteLine($"The value of red: {value}");
            }

            if (stock.TryRemove("red", out int removedValue))
            {
                Console.WriteLine($"Removed red with a value of {removedValue}");
            }

            foreach (var item in stock)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
