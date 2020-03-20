using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Abstractions.Pagination;
using NetModular.Module.Forum.Domain.TopicTag.Models;

namespace NetModular.Module.Forum.Domain.TopicTag
{
    /// <summary>
    /// 主题标签仓储
    /// </summary>
    public interface ITopicTagRepository : IRepository<TopicTagEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<TopicTagEntity>> Query(TopicTagQueryModel model);
    }
}
