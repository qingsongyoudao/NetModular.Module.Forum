using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Module.Forum.Domain.Mark.Models;

namespace NetModular.Module.Forum.Domain.Mark
{
    /// <summary>
    /// 标记信息仓储
    /// </summary>
    public interface IMarkRepository : IRepository<MarkEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<MarkEntity>> Query(MarkQueryModel model);

        /// <summary>
        /// 获取点赞和踩的总数
        /// </summary>
        /// <param name="TopicId">主题ID</param>
        /// <param name="type">MarkType枚举</param>
        /// <returns></returns>
        Task<long> Count(int TopicId, MarkType type);
    }
}
