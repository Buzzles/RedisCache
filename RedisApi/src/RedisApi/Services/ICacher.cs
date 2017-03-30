using RedisApi;
using RedisApi.Data;
using System;

public interface ICacher
{
    string Get(string key);

    void Set(string key, string value);

    void Expire(string key);

    void SetAdd<T>(string cacheKey, T simpleObj);

    T SetGet<T>(string cacheKey, Guid id) where T : SimpleDomainObject;
}