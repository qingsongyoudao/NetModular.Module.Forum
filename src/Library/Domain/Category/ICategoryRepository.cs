using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Abstractions.Pagination;
using NetModular.Module.Forum.Domain.Category.Models;

namespace NetModular.Module.Forum.Domain.Category
{
    /// <summary>
    /// 分类仓储
    /// </summary>
    public interface ICategoryRepository : IRepository<CategoryEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<CategoryEntity>> Query(CategoryQueryModel model);
    }
}
