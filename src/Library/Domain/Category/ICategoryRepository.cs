using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
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
        /// <summary>
        /// 增加统计值
        /// </summary>
        /// <param name="categoryIds"></param>
        /// <param name="isAddCount">是否累加</param>
        /// <param name="uow"></param>
        /// <returns></returns>
        Task<bool> AddCount(int[] categoryIds, bool isAddCount, IUnitOfWork uow = null);

        /// <summary>
        /// 重新计算
        /// </summary>
        /// <param name="categoryIds"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        Task<int> RecalculationCount(int[] categoryIds, IUnitOfWork uow = null);

        /// <summary>
        /// 获取所有分类数据
        /// </summary>
        /// <returns></returns>
        Task<IList<CategoryEntity>> GetList();
    }
}
