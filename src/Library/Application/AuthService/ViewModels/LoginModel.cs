using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.Forum.Application.AuthService.ViewModels
{
    /// <summary>
    /// 登录模型
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage = "邮箱地址不能为空")]
        [EmailAddress(ErrorMessage = "邮箱地址无效")]
        public string Email { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        [MinLength(6, ErrorMessage = "用户名不能小于6位")]
        [MaxLength(30, ErrorMessage = "用户名不能大于30位")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
    }
}
