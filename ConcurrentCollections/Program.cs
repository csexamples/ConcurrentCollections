using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new ConcurrentQueue<string>();

            Task task1 = Task.Run(() => PlaceOrders(orders, "Mark"));

            Task task2 = Task.Run(() => PlaceOrders(orders, "Susan"));

            Task.WaitAll(task1, task2);

            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }

        static void PlaceOrders(ConcurrentQueue<string> orders, string name)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1);

                string orderName = $"{name} wants a t-shirt - {i}";

                orders.Enqueue(orderName);
            }
        }
    }
}
