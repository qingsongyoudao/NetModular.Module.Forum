using System.ComponentModel;

namespace NetModular.Module.Forum.Domain.Mark
{
    /// <summary>
    /// 标记类型
    /// </summary>
    public enum MarkType
    {
        [Description("问题赞")]
        QuestionUp = 0,
        [Description("问题踩")]
        QuestionDown = 1,
        [Description("问题喜欢")]
        QuestionLike = 2,
        [Description("评论赞")]
        CommentUp = 3,
        [Description("评论踩")]
        CommentDown = 4,
        [Description("评论喜欢")]
        CommentLike = 5
    }
}
