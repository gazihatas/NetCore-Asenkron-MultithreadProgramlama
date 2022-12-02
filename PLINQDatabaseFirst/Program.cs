using System;
using System.Linq;
using PLINQDatabaseFirst.Models;

namespace PLINQDatabaseFirst
{
    internal class Program
    {
        private static void WriteLog(Product p)
        {
            //log'a yazdık
            Console.WriteLine(p.Name + "log'a kaydedildi.");
        }

        static void Main(string[] args)
        {
            AdventureWorks2017Context context = new AdventureWorks2017Context();

            //context.Products.Take(10).ToList().ForEach(x =>
            //{
            //    Console.WriteLine(x.Name);
            //});


            //var product = (from p in context.Products.AsParallel()
            //               where p.ListPrice > 10M
            //               select p).Take(10);
             context.Products.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism).ForAll(p=>
             {
                 
               WriteLog(p);  
             }); 

            //product.ToList().ForEach(x =>
            //{
            //    Console.WriteLine(x);
            //});

            //product.ForAll(x => { Console.WriteLine(x.Name); });
        }

    }
}
