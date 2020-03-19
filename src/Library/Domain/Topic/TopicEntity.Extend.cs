using NetModular.Lib.Data.Abstractions.Attributes;

namespace NetModular.Module.Forum.Domain.Topic
{
    public partial class TopicEntity
    {
        /// <summary>
        /// 昵称
        /// </summary>
        [Ignore] public string NickName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Ignore] public int Sex { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [Ignore] public string Avatar { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        [Ignore] public string CategoryName { get; set; }
    }
}
