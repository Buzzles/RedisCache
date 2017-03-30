using System;

namespace RedisApi.Data
{
    public class SimpleDomainObject : ISimpleDomainObject
    {
        public Guid Id { get; set; }
        public string Data { get; set; }

        public override bool Equals(object obj)
        {
            var comp = obj as SimpleDomainObject;

            if (comp.Data == this.Data && comp.Id == this.Id)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Id: {this.Id}, Data: {this.Data}";
        }
    }
}