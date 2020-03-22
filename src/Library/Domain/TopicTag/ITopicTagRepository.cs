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

        /// <summary>
        /// 删除通过标签编号
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        Task<bool> DeleteByTagId(int tagId, IUnitOfWork uow = null);

        /// <summary>
        /// 删除通过主题编号
        /// </summary>
        /// <param name="topicId"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        Task<bool> DeleteByTopicId(int topicId, IUnitOfWork uow = null);
    }
}
