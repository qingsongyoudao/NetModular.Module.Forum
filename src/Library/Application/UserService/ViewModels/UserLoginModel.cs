using System;
using System.ComponentModel.DataAnnotations;
using NetModular.Module.Forum.Domain.User;

namespace NetModular.Module.Forum.Application.UserService.ViewModels
{
    /// <summary>
    /// 用户信息添加模型
    /// </summary>
    public class UserLoginModel
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Password { get; set; }

    }
}
