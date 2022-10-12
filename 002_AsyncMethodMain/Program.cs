using System;
using System.Threading;
using System.Threading.Tasks;

namespace _002_AsyncMethodMain
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Method main started in thread: {Thread.CurrentThread.ManagedThreadId}");

            await WriteCharAsync('#');

            WriteChar('*');

            Console.WriteLine($"Method main ended in thread: {Thread.CurrentThread.ManagedThreadId}");

            Console.ReadKey();

        }

        private static async Task WriteCharAsync(char symbol)
        {
            Console.WriteLine($"Метод WriteCharAsync начал свою работу в потоке {Thread.CurrentThread.ManagedThreadId}");

            await Task.Run(() => WriteChar(symbol));

            Console.WriteLine($"-------Метод WriteCharAsync закончил свою работу в потоке {Thread.CurrentThread.ManagedThreadId}");

        }

        private static void WriteChar(char symbol)
        {
            Console.WriteLine($"Метод WriteChar Id потока - {Thread.CurrentThread.ManagedThreadId} , Id задачи - {Task.CurrentId}");

            Thread.Sleep(500);

            for (int i = 0; i < 50; i++)
            {
                Console.Write(symbol);
                Thread.Sleep(100);
            }

        }
    }
}
