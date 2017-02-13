using StackExchange.Redis;
using System;

namespace RedisCache
{
    public static class StaticCacher
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(
        () =>
        {
            const string connectionString = "192.168.99.100:6397,abortConnect=false,ssl=true,password=sdsd";
            return ConnectionMultiplexer.Connect(connectionString);
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