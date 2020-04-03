using System.Threading.Tasks;
using NetModular.Module.Forum.Application.MarkService.ViewModels;
using NetModular.Module.Forum.Domain.Mark;
using NetModular.Module.Forum.Domain.Mark.Models;

namespace NetModular.Module.Forum.Application.MarkService
{
    /// <summary>
    /// 标记信息服务
    /// </summary>
    public interface IMarkService
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Query(MarkQueryModel model);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Add(MarkAddModel model);

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
        Task<IResultModel> Update(MarkUpdateModel model);

        /// <summary>
        /// 获取点赞和踩的总数
        /// </summary>
        /// <param name="TopicId">主题ID</param>
        /// <param name="type">MarkType枚举</param>
        /// <returns></returns>
        Task<IResultModel> Count(int TopicId, MarkType type);
    }
}
