using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelFor_ForEach_Thread_LocalVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int total = 0;

            Parallel.ForEach(Enumerable.Range(1, 100).ToList(), () => 0, (x, loop, subtotal) =>
            {
                subtotal += x;
                return subtotal;
            }, (y)=> Interlocked.Add(ref total, y));


            Console.WriteLine(total);

            Parallel.For(0, 100, () => 0, (x, LoaderOptimization, subtotal) =>
            {
                subtotal = x;
                return subtotal;
            }, (y)=>Interlocked.Add(ref total, y));
        }
    }
}
