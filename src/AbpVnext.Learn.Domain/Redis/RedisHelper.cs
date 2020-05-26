using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace AbpVnext.Learn.Redis
{
    public class RedisHelper: DomainService, IRedisHelper
    {
        private IDistributedCache _redis;
        public RedisHelper(IDistributedCache redis)
        {
            _redis = redis;
        }
        /// <summary>
        /// 插入字符串异步
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存值</param>
        /// <param name="seconds">为0时是则不设置过期时间</param>
        /// <returns></returns>
        public async Task StringSetAsync(string key, string value, int seconds=0)
        {
            if (seconds > 0)
                 await _redis.SetStringAsync(key, value,new DistributedCacheEntryOptions() {SlidingExpiration=TimeSpan.FromSeconds(seconds) } );
            else
                 await _redis.SetStringAsync(key, value);
        }
        /// <summary>
        /// 获取字符串异步
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<string> StringGetAsync(string key)
        {
            var data = await _redis.GetStringAsync(key);
            if (String.IsNullOrEmpty(data))
            {
                return null;
            }
            return data;
        }
        /// <summary>
        /// 删除key,异步
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task RemoveAsync(string key)
        {
             await _redis.RemoveAsync(key);
        }
    }
}
