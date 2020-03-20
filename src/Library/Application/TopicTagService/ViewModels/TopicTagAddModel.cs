using System;
using System.ComponentModel.DataAnnotations;
using NetModular.Module.Forum.Domain.TopicTag;

namespace NetModular.Module.Forum.Application.TopicTagService.ViewModels
{
    /// <summary>
    /// 主题标签添加模型
    /// </summary>
    public class TopicTagAddModel
    {
        /// <summary>
        /// 主题ID
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// 标签ID
        /// </summary>
        public int TagId { get; set; }

    }
}
