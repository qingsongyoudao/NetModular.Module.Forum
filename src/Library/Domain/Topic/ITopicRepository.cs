using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Abstractions.Pagination;
using NetModular.Module.Forum.Domain.Topic.Models;

namespace NetModular.Module.Forum.Domain.Topic
{
    /// <summary>
    /// 主题仓储
    /// </summary>
    public interface ITopicRepository : IRepository<TopicEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<TopicEntity>> Query(TopicQueryModel model);
    }
}
