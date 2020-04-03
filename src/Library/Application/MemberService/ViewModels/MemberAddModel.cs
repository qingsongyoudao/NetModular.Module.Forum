using System;
using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.Forum.Application.MemberService.ViewModels
{
    /// <summary>
    /// 用户信息添加模型
    /// </summary>
    public class MemberAddModel
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
        public string Avatar { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

    }
}
