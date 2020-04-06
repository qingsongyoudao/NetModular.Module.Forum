using System.ComponentModel;

namespace NetModular.Module.Forum.Domain.Mark
{
    /// <summary>
    /// 数据类型
    /// </summary>
    public enum DataType
    {
        [Description("未知")]
        Unknown = 0,
        [Description("问题")]
        Question = 1,
        [Description("评论")]
        Comment = 2,
        [Description("通知")]
        Notice = 3
    }
}
