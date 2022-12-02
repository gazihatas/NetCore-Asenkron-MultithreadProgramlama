using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ForEachParallelApp
{
    internal class Program
    {
        //Senaryo 20 adet resim alınacak boyutları küçültülecek.
        
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            
            sw.Start();
            string picturesPath = @"C:\Users\lion\Pictures\";

            var files = Directory.GetFiles(picturesPath);

            Parallel.ForEach(files, (item) =>
            {
                Console.WriteLine("thread no: " + Thread.CurrentThread.ManagedThreadId);

                Image img = new Bitmap(item);
                var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

                thumbnail.Save(Path.Combine(picturesPath, "thumbnail", Path.GetFileName(item)));



            });

            sw.Stop();

            Console.WriteLine("İşlem bitti:" + sw.ElapsedMilliseconds);

            sw.Reset();
            sw.Start();
            files.ToList().ForEach(x =>
            {
                Console.WriteLine("thread no: " + Thread.CurrentThread.ManagedThreadId);

                Image img = new Bitmap(x);
                var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

                thumbnail.Save(Path.Combine(picturesPath, "thumbnail", Path.GetFileName(x)));
            });
            sw.Stop();

            Console.WriteLine("İşlem bitti:" + sw.ElapsedMilliseconds);
        }
    }
}
