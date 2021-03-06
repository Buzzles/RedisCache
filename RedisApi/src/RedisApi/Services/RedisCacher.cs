﻿using System;
using StackExchange.Redis;
using Newtonsoft.Json;
using System.Linq;
using RedisApi;
using RedisApi.Data;

public class RedisCacher : ICacher
{
    private IConnectionMultiplexer _connection;

    private IDatabase _db;

    public RedisCacher()
    {
        var configOptions = new ConfigurationOptions();

        configOptions.EndPoints.Add("192.168.99.100:6379");
        configOptions.ClientName = "LocalRedis";
        configOptions.ConnectTimeout = 1000;
        configOptions.SyncTimeout = 1000;

        _connection = ConnectionMultiplexer.Connect(configOptions);

        _db = _connection.GetDatabase();
    }

    public void Expire(string key)
    {
        _db.KeyExpire(key, new TimeSpan(0L));
    }

    public string Get(string key)
    {
        var value = string.Empty;
        value = _db.StringGet(key);

        return value;
    }

    public void Set(string key, string value)
    {
        _db.StringSet(key, value);
    }

    public void SetAdd<T>(string cacheKey, T simpleObj)
    {
        var serialisedObj = JsonConvert.SerializeObject(simpleObj);
        _db.SetAdd(cacheKey, serialisedObj);
    }

    public T SetGet<T>(string cacheKey, Guid id) where T : SimpleDomainObject
    {
        var value = string.Empty;
        var set = _db.SetMembers(cacheKey);

        var item = set.Select(x => JsonConvert.DeserializeObject<T>(x)).FirstOrDefault(y => y.Id == id);

        return item;
    }

    public void HashSet(string key, object item)
    {
        var entry = new HashEntry("prop1", "wobble");
        HashEntry[] hashfields = null;
        _db.HashSet(key, hashfields);
    }

    public void HashGet(string key, Guid id)
    {
        var value = _db.HashGet(key, "id");
    }
}