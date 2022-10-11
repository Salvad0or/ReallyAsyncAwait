using System;
using System.Threading;
using System.Threading.Tasks;

namespace ReallyAsyncAwait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 0;

            int b = a = 1;

            Console.WriteLine($"A - {a}, B - {b}");

            Console.ReadKey();

            Console.WriteLine($"Метод Main начал свою работу в потоке {Thread.CurrentThread.ManagedThreadId}");

            WriteCharAsync('#'); // Запуск асинхронно
            WriteChar('*'); // Запуск синхронно

            Console.WriteLine($"Метод Main закончил свою работу в потоке {Thread.CurrentThread.ManagedThreadId}");

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
