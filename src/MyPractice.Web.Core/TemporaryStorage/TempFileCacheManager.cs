using Abp.Dependency;
using Abp.Runtime.Caching;
using System;

namespace MyPractice.TemporaryStorage
{
    public class TempFileCacheManager : ITempFileCacheManager
    {
        //临时文件缓存名称
        public const string TempFileCacheName = "TempFileCacheName";

        private readonly ICacheManager _cacheManager;

        public TempFileCacheManager(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public void SetFile(string token, byte[] content)
        {
            _cacheManager.GetCache(TempFileCacheName).Set(token, content, new TimeSpan(0, 0, 1, 0)); // 过期时间默认为1分钟
        }

        public byte[] GetFile(string token)
        {
            return _cacheManager.GetCache(TempFileCacheName).Get(token, ep => ep) as byte[];
        }
    }

    public interface ITempFileCacheManager : ITransientDependency
    {
        void SetFile(string token, byte[] content);

        byte[] GetFile(string token);
    }
}
