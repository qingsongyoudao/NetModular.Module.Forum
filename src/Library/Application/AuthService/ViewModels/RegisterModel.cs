using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.Forum.Application.AuthService.ViewModels
{
    /// <summary>
    /// 用户注册模型
    /// </summary>
    public class RegisterModel
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
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        [MinLength(6, ErrorMessage = "密码不能小于10位")]
        [MaxLength(50, ErrorMessage = "用户名不能大于50位")]
        public string Password { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; } = 0;
    }
}
