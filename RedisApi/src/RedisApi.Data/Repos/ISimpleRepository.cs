using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisApi.Data.Repos
{
    public interface ISimpleRepository<T> where T : ISimpleDomainObject
    {
        void Add(T obj);

        void Update(T obj);

        void Delete(T obj);
    }
}
