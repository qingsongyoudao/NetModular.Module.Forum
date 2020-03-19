using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Abstractions.Pagination;
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
    }
}
