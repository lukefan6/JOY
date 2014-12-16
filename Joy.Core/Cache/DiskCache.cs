using System.IO;
using Joy.Core.Cache.Base;
using Newtonsoft.Json;

namespace Joy.Core.Cache
{
    public class DiskCache : ICache
    {
        private string CacheLocation
        {
            get
            {
                string location = AppSettingConfig.GetAppSettingOrDefault(
                    "DiskCacheLocation",
                    @"C:\Joy.Core.DiskCache\");

                if (!Directory.Exists(location)) { Directory.CreateDirectory(location); }

                return location;
            }
        }

        private string GetObjectInfoPath(string key)
        {
            return string.Concat(CacheLocation, key, ".json");
        }

        #region ICache 成員

        bool ICache.Add(string key, object value)
        {
            try
            {
                File.WriteAllText(
                    GetObjectInfoPath(key),
                    JsonConvert.SerializeObject(value));

                return true;
            }
            catch
            {
                return false;
            }
        }

        T ICache.Get<T>(string key)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(GetObjectInfoPath(key)));
        }

        bool ICache.HasValue(string key)
        {
            return File.Exists(GetObjectInfoPath(key));
        }

        bool ICache.Remove(string key)
        {
            string objInfoPath = GetObjectInfoPath(key);
            if (!File.Exists(objInfoPath)) { return true; }

            try
            {
                File.Delete(objInfoPath);

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
