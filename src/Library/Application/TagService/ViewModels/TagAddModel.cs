using System;
using System.ComponentModel.DataAnnotations;
using NetModular.Module.Forum.Domain.Tag;

namespace NetModular.Module.Forum.Application.TagService.ViewModels
{
    /// <summary>
    /// 标签添加模型
    /// </summary>
    public class TagAddModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 主题数量
        /// </summary>
        public int Count { get; set; }

    }
}
