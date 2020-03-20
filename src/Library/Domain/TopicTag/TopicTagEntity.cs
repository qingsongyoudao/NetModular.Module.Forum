using System;
using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities;

namespace NetModular.Module.Forum.Domain.TopicTag
{
    /// <summary>
    /// 主题标签
    /// </summary>
    [Table("Topic_Tag")]
    public partial class TopicTagEntity : Entity<int>
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
