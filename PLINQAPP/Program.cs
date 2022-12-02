using System;
using System.Linq;

namespace PLINQAPP
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
            
            array.Where(x => x % 2 == 0).ToList().ForEach(x =>
            {
                Console.WriteLine(x);
            });

            
            var newArray = array.AsParallel().Where(x => x % 2 == 0);

            newArray.ToList().ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }
    }
}
