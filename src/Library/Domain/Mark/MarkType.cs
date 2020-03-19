using System.ComponentModel;

namespace NetModular.Module.Forum.Domain.Mark
{
    /// <summary>
    /// 标记类型
    /// </summary>
    public enum MarkType
    {
        [Description("主题赞")]
        TopicUp = 0,
        [Description("主题踩")]
        TopicDown = 1,
        [Description("主题喜欢")]
        TopicLike = 2,
        [Description("评论赞")]
        CommentUp = 3,
        [Description("评论踩")]
        CommentDown = 4,
        [Description("评论喜欢")]
        CommentLike = 5
    }
}
