using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Module.Forum.Domain.Tag.Models;

namespace NetModular.Module.Forum.Domain.Tag
{
    /// <summary>
    /// 标签仓储
    /// </summary>
    public interface ITagRepository : IRepository<TagEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<TagEntity>> Query(TagQueryModel model);

        /// <summary>
        /// 增加统计值
        /// </summary>
        /// <param name="tagIds"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        Task<bool> AddCount(int[] tagIds, bool isAdd, IUnitOfWork uow = null);

        /// <summary>
        /// 重新计算
        /// </summary>
        /// <param name="tagIds"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        Task<int> RecalculationCount(int[] tagIds, IUnitOfWork uow = null);
    }
}
