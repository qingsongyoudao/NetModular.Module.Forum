using System;
using System.Threading.Tasks;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.Forum.Application.CategoryService.ViewModels;
using NetModular.Module.Forum.Domain.Category.Models;

namespace NetModular.Module.Forum.Application.CategoryService
{
    /// <summary>
    /// 分类服务
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Query(CategoryQueryModel model);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Add(CategoryAddModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        Task<IResultModel> Delete(int id);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> Edit(int id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Update(CategoryUpdateModel model);

        Task<IResultModel> Select();
    }
}
