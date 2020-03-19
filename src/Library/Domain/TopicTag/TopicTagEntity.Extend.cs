using NetModular.Lib.Data.Abstractions.Attributes;

namespace NetModular.Module.Forum.Domain.TopicTag
{
    public partial class TopicTagEntity
    {
        /// <summary>
        /// 主题标题
        /// </summary>
        [Ignore] public string TopicTitle { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
        [Ignore] public string TagName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Ignore] public string NickName { get; set; }

    }
}
