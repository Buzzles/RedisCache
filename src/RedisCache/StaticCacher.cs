using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisCache
{
    public static class StaticCacher
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(
        () =>
        {
            return ConnectionMultiplexer.Connect("192.168.99.100:6397,abortConnect=false,ssl=true,password=...");
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
