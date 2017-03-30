using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisApi.Data.Repos
{
    public class SimpleRepository<T> : ISimpleRepository<T> where T : SimpleDomainObject
    {
        private readonly Context _context;

        public SimpleRepository(Context context)
        {
            _context = context;
        }

        public void Add(T obj)
        {
            if (obj != null)
            {
                _context.Add(obj);
            }
        }

        public void Delete(T obj)
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            if (obj != null)
            {
                _context.Update(obj);
            }
        }
    }
}
