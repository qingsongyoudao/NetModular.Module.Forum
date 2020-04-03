using System.Threading.Tasks;
using NetModular.Module.Forum.Application.AuthService.ViewModels;

namespace NetModular.Module.Forum.Application.AuthService
{
    /// <summary>
    /// 认证服务
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Register(RegisterModel model);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Login(LoginModel model);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> ChangePassword(ChangePasswordModel model);
    }
}
