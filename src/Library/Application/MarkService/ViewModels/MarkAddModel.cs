using System;
using System.ComponentModel.DataAnnotations;
using NetModular.Module.Forum.Domain.Mark;

namespace NetModular.Module.Forum.Application.MarkService.ViewModels
{
    /// <summary>
    /// 标记信息添加模型
    /// </summary>
    public class MarkAddModel
    {
        /// <summary>
        /// 类型
        /// </summary>
        public MarkType Type { get; set; }

        /// <summary>
        /// 主题Id
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

    }
}
