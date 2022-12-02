using System;
using System.Linq;
using System.Threading;

namespace ForAll
{
    internal class Program
    {
        private static bool Islem(int x)
        {
            return x % 2 == 0;
        }
        static void Main(string[] args)
        {

            var array = Enumerable.Range(1, 100).ToList();

            var newArray = array.AsParallel().Where(x => x % 2 == 0);

            newArray.ForAll(x =>
            {
                Thread.Sleep(500);
                Console.WriteLine(x);
            });
        }
    }
}
