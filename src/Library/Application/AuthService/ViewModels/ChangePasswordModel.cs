using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.Forum.Application.AuthService.ViewModels
{
    /// <summary>
    /// 修改密码模型
    /// </summary>
    public class ChangePasswordModel
    {
        /// <summary>
        /// 旧密码
        /// </summary>
        [Required(ErrorMessage = "旧密码不能为空")]
        public string OldPassword { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        [Required(ErrorMessage = "新密码不能为空")]
        public string NewPassword { get; set; }

        /// <summary>
        /// 确认密码
        /// </summary>
        [Required(ErrorMessage = "确认密码不能为空")]
        public string ConfirmPassword { get; set; }
    }
}
