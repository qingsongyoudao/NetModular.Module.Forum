using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities;
using NetModular.Lib.Data.Core.Entities.Extend;
using System;

namespace NetModular.Module.Forum.Domain.Member
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("Member")]
    public partial class MemberEntity : EntityBaseWithSoftDelete<int, Guid>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

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
