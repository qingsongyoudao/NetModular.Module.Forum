using NetModular.Lib.Auth.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetModular.Module.Forum.Application.MemberService.ViewModels
{
    public class MemberLoginModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "请输入用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; }

        /// <summary>
        /// 账户类型
        /// </summary>
        [Required(ErrorMessage = "请选择账户类型")]
        public AccountType AccountType { get; set; } = AccountType.Admin;

        /// <summary>
        /// 平台
        /// </summary>
        public Platform Platform { get; set; }

        /// <summary>
        /// 验证码
        ///  Admin.Application.AuthService.ViewModels.VerifyCodeModel
        /// </summary>
        //public Admin.Application.AuthService.ViewModels.VerifyCodeModel VerifyCode { get; set; }
    }
}
