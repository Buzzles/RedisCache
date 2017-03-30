using System;

namespace RedisApi.Data
{
    public interface ISimpleDomainObject
    {
        Guid Id { get; set; }
    }
}