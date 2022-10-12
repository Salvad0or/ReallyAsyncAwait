using System;
using System.Threading.Tasks;

namespace ParralelFor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(1, 5, TplTest1);

            Console.ReadKey();


        }

        static void TplTest1(int i)
        {
            Console.WriteLine($"Метод ParallelFor передал {i}");
        }

        /// Метод будет выполнятся параллельно
        /// 1 - это начальная точка итераций
        /// 5 - до какого числа не включительно будет продолжаться итерация
        /// ну и сам метод принимающий значения от 1 - 4.
    }
}
