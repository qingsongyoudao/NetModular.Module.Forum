using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Module.Forum.Domain.User.Models;

namespace NetModular.Module.Forum.Domain.User
{
    /// <summary>
    /// 用户信息仓储
    /// </summary>
    public interface IUserRepository : IRepository<UserEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<UserEntity>> Query(UserQueryModel model);
    }
}
