using System;
using StackExchange.Redis;
using Newtonsoft.Json;
using System.Linq;
using RedisCache;
using System.Reflection;

public static class RedisUtils
{
    // Serialise in RedisFormat
    public static HashEntry[] ToHashEntries(this object obj)
    {
        var propInfo = obj.GetType().GetProperties();
 
         return propInfo
                .Where(x => x.GetValue(obj) != null)
                .Select(p => new HashEntry(
                                    p.Name,
                                    p.GetValue(obj).ToString()))
                .ToArray();
    }
    // DeserializeObject
    public static T ConvertFromRedis<T>(this HashEntry[] hashEntries)
    {
        var propInfo = typeof(T).GetProperties();
        var newObj = Activator.CreateInstance(typeof(T)); // HORRIFIC!

        foreach(var prop in propInfo)
        {
            var entry = hashEntries.FirstOrDefault(h => h.Name.ToString().Equals(prop.Name));

            if(entry.Equals(new HashEntry()))
            {
                continue;
            }
            prop.SetValue(newObj, Convert.ChangeType(entry.Value.ToString(), prop.PropertyType));

        }
        return (T)newObj;
    }
}