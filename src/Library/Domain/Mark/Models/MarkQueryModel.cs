using System;
using NetModular.Lib.Data.Query;

namespace  NetModular.Module.Forum.Domain.Mark.Models
{
    public class MarkQueryModel : QueryModel
    {
        /// <summary>
        /// 主题Id
        /// </summary>
        public int TopicId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public MarkType? Type { get; set; }

    }
}
