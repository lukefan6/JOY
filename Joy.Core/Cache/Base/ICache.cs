
namespace Joy.Core.Cache.Base
{
    public interface ICache
    {
        bool Add(string key, object value);

        T Get<T>(string key);

        bool HasValue(string key);

        bool Remove(string key);
    }
}
