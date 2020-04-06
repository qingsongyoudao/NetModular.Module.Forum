using System;
using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities;

namespace NetModular.Module.Forum.Domain.Mark
{
    /// <summary>
    /// 标记信息
    /// </summary>
    [Table("Mark")]
    public partial class MarkEntity : Entity<int>
    {
        /// <summary>
        /// 类型
        /// </summary>
        public MarkType Type { get; set; }

        /// <summary>
        /// 关联编号
        /// </summary>
        public int RelationId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

    }
}
