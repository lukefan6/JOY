using System;
using Joy.Core.Cache.Base;

namespace Joy.Core.DataAccess.Base
{
    public class Proxy<T> where T : class
    {
        protected ICache _cache;
        protected string _key;
        protected Func<T> _retriever;

        public Proxy(string key, Func<T> retriever)
        {
            _key = key;
            _cache = CacheFactory.Get();
            _retriever = retriever;
        }

        public virtual void Add(T value)
        {
            _cache.Add(_key, value);
        }

        public virtual void Clear()
        {
            if (_cache.HasValue(_key)) { _cache.Remove(_key); }
        }

        public virtual T Get()
        {
            if (!_cache.HasValue(_key)) { this.Retrieve(); }

            return _cache.Get<T>(_key);
        }

        public virtual void Reset()
        {
            this.Clear();
            this.Retrieve();
        }

        public virtual void Update(T value)
        {
            this.Clear();
            this.Add(value);
        }

        protected virtual void Retrieve()
        {
            _cache.Add(_key, _retriever.Invoke());
        }
    }
}
