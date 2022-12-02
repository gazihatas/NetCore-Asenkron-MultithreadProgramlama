using System;
using System.Linq;
using PLINQDatabaseFirst.Models;

namespace PLINQDatabaseFirst
{
    internal class Program
    {
        private static bool IsControl(Product p)
        {
            try
            {
                return p.Name[2] == 'a';
            }
            catch (Exception ex)
            {
                Console.WriteLine("Dizi sınırları aşıldı");
                return false;
            }
        }

        private static void WriteLog(Product p)
        {
            //log'a yazdık
            Console.WriteLine(p.Name + "log'a kaydedildi.");
        }

        static void Main(string[] args)
        {
            AdventureWorks2017Context context = new AdventureWorks2017Context();


            var products = context.Products.Take(100).ToArray();

            products[3].Name = "##";

            products[5].Name = "##";

            var query = products.AsParallel().Where(IsControl);

            try
            {
                query.ForAll(x =>
                {
                    Console.WriteLine($"{x.Name}");
                });
            }
            catch (AggregateException ex)
            {
                ex.InnerExceptions.ToList().ForEach(x =>
                {
                    if (x is IndexOutOfRangeException)
                    {
                        Console.WriteLine($"Hata: array sınırları dışına çıkıldı");
                    }
                    
                });
                
            }


            //context.Products.AsParallel().AsOrdered().Where(p => p.ListPrice > 10M).ToList().ForEach(x =>
            //{
            //    Console.WriteLine($"{x.Name} - {x.ListPrice}");
            //});


            //context.Products.Take(10).ToList().ForEach(x =>
            //{
            //    Console.WriteLine(x.Name);
            //});


            //var product = (from p in context.Products.AsParallel()
            //               where p.ListPrice > 10M
            //               select p).Take(10);
            //context.Products.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism).ForAll(p=>
            //{

            //  WriteLog(p);  
            //}); 

            //product.ToList().ForEach(x =>
            //{
            //    Console.WriteLine(x);
            //});

            //product.ForAll(x => { Console.WriteLine(x.Name); });
        }

    }
}
