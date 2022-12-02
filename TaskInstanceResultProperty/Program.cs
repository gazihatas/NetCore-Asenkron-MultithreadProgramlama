using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskInstanceResultProperty
{
    internal class Program
    {
        private async static Task Main(string[] args)
        {
            Console.WriteLine(GetData());
        }

        public static string GetData()
        {
            var task = new HttpClient().GetStringAsync("https://www.google.com");

            return task.Result;
        }
    }
}
