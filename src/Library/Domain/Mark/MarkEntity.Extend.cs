using NetModular.Lib.Data.Abstractions.Attributes;

namespace NetModular.Module.Forum.Domain.Mark
{
    public partial class MarkEntity
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
        /// 数据类型
        /// </summary>
        [Ignore] public string MarkTypeDesc => this.Type.ToDescription();
    }
}
