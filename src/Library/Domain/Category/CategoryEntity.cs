using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities;

namespace NetModular.Module.Forum.Domain.Category
{
    /// <summary>
    /// 分类
    /// </summary>
    [Table("Category")]
    public partial class CategoryEntity : Entity<int>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Length(100)]
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 主题数量
        /// </summary>
        public int Count { get; set; }

    }
}
