using System;
using System.Threading.Tasks;

namespace ValueTask
{
    internal class Program
    {
        public static int cachedata { get; set; }
        private  async static Task Main(string[] args)
        {
            var mytask = GetData();
        }

        public static ValueTask<int> GetData()
        {
            return new ValueTask<int>(cachedata);
        }
    }
}
