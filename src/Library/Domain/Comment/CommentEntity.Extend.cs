using NetModular.Lib.Data.Abstractions.Attributes;

namespace NetModular.Module.Forum.Domain.Comment
{
    public partial class CommentEntity
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

        #region To 
        /// <summary>
        /// 昵称
        /// </summary>
        [Ignore] public string ToNickName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Ignore] public int ToSex { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [Ignore] public string ToAvatar { get; set; }

        #endregion 
    }
}
