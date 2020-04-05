using System.Threading.Tasks;
using NetModular.Module.Forum.Application.AuthService.ViewModels;
using NetModular.Module.Forum.Domain.Member;

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

        /// <summary>
        /// 检查邮箱是否
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<IResultModel> CheckEmail(string email);

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<IResultModel> CheckUserName(string userName);
    }
}
