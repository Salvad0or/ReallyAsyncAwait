using System;
using System.Threading;

namespace TroelsenTimer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(Time,null,0,1000);

            timer = new Timer(State, "Ha-ha", 0, 1000);

            var _ = new Timer(State, "Ho-ho", 0, 1000); /// это вот так вот можно


            Console.ReadLine();
        }


        public static void Time(object _)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }

        public static void State(object state)
        {
            /// здесь мы вызываем таймер, и вместо null что то ему передаем
            /// учитывая, что это obj - можно творить магию
            /// но я слишком ленив и кинул стринг хаха

            for (int i = 0; i < 50; i++)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write(state);

            }

        }
    }
}
