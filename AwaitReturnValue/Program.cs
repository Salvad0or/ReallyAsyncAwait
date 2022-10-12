using System;
using System.Threading;
using System.Threading.Tasks;

namespace AwaitReturnValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 3, y = 5;

            Task<int> additionalTask = AdditionalAsync("[Асинхронно]", x, y);

            int suncSum = Additional("[Синхронно]", x, y);

            int asyncSum = 0;

            // Разные способы получения результатов задачи:

            asyncSum = additionalTask.Result;

            //asyncSum await additionTask;

            Console.WriteLine($"Результат асинхронного выполнения {asyncSum}");
            Console.WriteLine($"Результат синхронного выполнения {suncSum}");

            Console.WriteLine("Метод Main завершил свою работу");

            Console.ReadKey();
        }

        private static async Task<int> AdditionalAsync(string v, int x, int y)
        {
            /// Первый способ работы:
            
            return await Task.Run<int>(() => Additional(v, x, y));

            // ------------------------- //


            /// Второй способ:

            //int result =  await Task.Run<int>(() => Additional(v, x, y));

            //return result;


            // ------------------------- //

            ///// Ошибочный способ:

            //return Task.Run<int>(() => Additional(v, x, y));




        }

        private static int Additional (string v, int x, int y)
        {
            Console.WriteLine($"Метод Additional вызван {v} в потоке {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(3000);

            return x + y;
        }
    }
}
