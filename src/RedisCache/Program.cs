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

            Console.WriteLine("Adding an object");

            var simpleObj = new SimpleDomainObject
            {
                Id = Guid.NewGuid(),
                Data = ""
            };

            var setKey = "SetKey1";
            cacher.SetAdd(setKey, simpleObj);

            Console.WriteLine($"Getting object with key:{setKey} and Id:{simpleObj.Id}");
            var outObj = cacher.SetGet<SimpleDomainObject>(setKey, simpleObj.Id);
            Console.WriteLine($"Object contents: {outObj.ToString()}");

            Console.ReadKey();
        }

        public static void DoTheShit()
        {
            var cacher = new Cacher();
            var repo = new SimpleMemoryRepository(cacher);
        }
    }
}
