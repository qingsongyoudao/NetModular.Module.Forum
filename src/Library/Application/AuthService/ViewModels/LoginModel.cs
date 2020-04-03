using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.Forum.Application.AuthService.ViewModels
{
    /// <summary>
    /// 登录模型
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 邮箱或用户名不能为空
        /// </summary>
        [Required(ErrorMessage = "邮箱或用户名不能为空")]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
    }
}
