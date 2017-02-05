using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisCache
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            var cacher = new Cacher();

            cacher.Set("key1", "wobble");

            var value = cacher.Get("key1");

            Console.WriteLine($"Get key1 returns: {value}");

            Console.ReadKey();
        }

        public static void DoTheShit()
        {
            var cacher = new Cacher();
            var repo = new SimpleMemoryRepository(cacher);
        }
    }
}
