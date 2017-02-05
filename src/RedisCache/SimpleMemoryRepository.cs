using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisCache
{
    public class SimpleMemoryRepository
    {
        private List<SimpleDomainObject> _memory;

        private readonly ICacher _cacher;

        private string CacheKey => "CacheKey";

        private string CacheSetKey => "CacheSetKey";
        
        public SimpleMemoryRepository(ICacher cacher)
        {
            _cacher = cacher;
            _memory = new List<SimpleDomainObject>();
        }

        public void Add(SimpleDomainObject simpleObj)
        {
            if (!_memory.Exists(x => x.Equals(simpleObj)))
            {
                _memory.Add(simpleObj);
                _cacher.SetAdd(CacheKey, simpleObj);
            }
        }

        public void Update(SimpleDomainObject simpleObj)
        {
 
        }

        public void Remove(SimpleDomainObject simpleObj)
        {

        }

        public void Get(Guid id)
        {
            // Check cache
            // Get from memory       
        }
    }
}
