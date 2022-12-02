using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ForEachParallelApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long FilesByte = 0;

            Stopwatch sw = new Stopwatch();

            sw.Start();
            string picturesPath = @"C:\Users\lion\Pictures";

            var files = Directory.GetFiles(picturesPath);

            Parallel.ForEach(files, (item) =>
            {
                Console.WriteLine("thread no: " + Thread.CurrentThread.ManagedThreadId);

                FileInfo f = new FileInfo(item);

                Interlocked.Add(ref FilesByte, f.Length);


            });

            Console.WriteLine("toplam boyut:" + FilesByte.ToString());
        }
    }
}
