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

            // cacher.Set("key1", "wobble");

            // var value = cacher.Get("key1");

            // Console.WriteLine($"Get key1 returns: {value}");
            // Console.ReadKey();

            // Console.WriteLine("Adding an object");

            // var simpleObj = new SimpleDomainObject
            // {
            //     Id = Guid.NewGuid(),
            //     Data = "test"
            // };

            // var setKey = "SetKey1";
            // cacher.SetAdd(setKey, simpleObj);

            // var simpleObj2 = new SimpleDomainObject
            // {
            //     Id = Guid.NewGuid(),
            //     Data = "test2"
            // };
            // cacher.SetAdd(setKey, simpleObj2);

            // Console.WriteLine($"Getting set object with key:{setKey} and Id:{simpleObj2.Id}");
            // var outObj = cacher.SetGet<SimpleDomainObject>(setKey, simpleObj2.Id);
            // Console.WriteLine($"Object contents: {outObj.ToString()}");

            // Console.ReadKey();

            var hashKey = "HashKey1";

            var simpleObj3 = new SimpleDomainObject
            {
                Id = Guid.NewGuid(),
                Data = "test3"
            };
            
            Console.WriteLine($"Setting hash object with key:{hashKey} and Id:{simpleObj3.Id}");

            cacher.HashSet(hashKey, simpleObj3);

            Console.WriteLine($"Getting hash object with key:{hashKey} and Id:{simpleObj3.Id}");
            var hashoutObj = cacher.HashGet<SimpleDomainObject>(hashKey, simpleObj3.Id);
            Console.WriteLine($"Object contents: {hashoutObj.ToString()}");

            Console.ReadKey();
        }

        public static void DoTheShit()
        {
            var cacher = new Cacher();
            var repo = new SimpleMemoryRepository(cacher);
        }
    }
}
