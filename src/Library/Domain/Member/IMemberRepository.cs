using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Abstractions.Pagination;
using NetModular.Module.Forum.Domain.Member.Models;

namespace NetModular.Module.Forum.Domain.Member
{
    /// <summary>
    /// 用户信息仓储
    /// </summary>
    public interface IMemberRepository : IRepository<MemberEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<MemberEntity>> Query(MemberQueryModel model);

        bool ExistsEmail(string email);

        bool ExistsUserName(string userName);

        Task<MemberEntity> GetByUserName(string userName);
    }
}
