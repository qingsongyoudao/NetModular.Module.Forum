using System;
using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities;

namespace NetModular.Module.Forum.Domain.User
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("User")]
    public partial class UserEntity : Entity<int>
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [Length(300)]
        public string Avatar { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Length(300)]
        public string Email { get; set; }

    }
}
