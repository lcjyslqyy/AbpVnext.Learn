using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace AbpVnext.Learn.Redis
{
    public interface IRedisHelper : IDomainService
    {
        /// <summary>
        /// 插入字符串异步
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存值</param>
        /// <param name="seconds">为0时是则不设置过期时间</param>
        /// <returns></returns>
        Task StringSetAsync(string key, string value, int seconds = 0);
        /// <summary>
        /// 获取字符串异步
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<string> StringGetAsync(string key);
        /// <summary>
        /// 删除key,异步
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task RemoveAsync(string key);
    }
}
