using System.Threading.Tasks;

namespace NetModular.Module.Forum.Application.CacheService
{
    /// <summary>
    /// 缓存服务
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// 刷新用户邮箱集合
        /// </summary>
        /// <returns></returns>
        Task RefreshUserEmail();

        /// <summary>
        /// 刷新用户名集合
        /// </summary>
        /// <returns></returns>
        Task RefreshUserName();
    }
}
