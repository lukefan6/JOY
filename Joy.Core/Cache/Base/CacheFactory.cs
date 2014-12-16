using System;

namespace Joy.Core.Cache.Base
{
    public static class CacheFactory
    {
        private static string TypeName
        {
            get
            {
                return AppSettingConfig.GetAppSettingOrDefault(
                    "CacheName",
                    "Joy.Core.Cache.DiskCache");
            }
        }

        public static ICache Get()
        {
            var type = Type.GetType(TypeName);
            return Activator.CreateInstance(type) as ICache;
        }
    }
}
