using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Auth.Web;
using NetModular.Module.Forum.Application.AuthService;
using NetModular.Module.Forum.Application.AuthService.ViewModels;

namespace NetModular.Module.Forum.Web.Controllers.App
{
    [Description("授权")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _service;
        private readonly ILoginHandler _loginHandler;

        public AuthController(IAuthService service, ILoginHandler loginHandler)
        {
            _service = service;
            _loginHandler = loginHandler;
        }

        [HttpGet]
        [Description("获取验证码")]
        public IResultModel VerifyCode(int length = 6)
        {
            return ResultModel.Failed();//  _ service.CreateVerifyCode(length);
        }

        [HttpPost]
        [Description("登录")]
        public async Task<IResultModel> Login([FromBody]LoginModel model)
        {
            return await _service.Login(model);
        }

        [HttpPost]
        [Description("注册")]
        public async Task<IResultModel> Register([FromBody]RegisterModel model)
        {
            return await _service.Register(model);
        }

        [HttpGet]
        [Description("刷新令牌")]
        public async Task<IResultModel> RefreshToken([BindRequired]string refreshToken)
        {
            return await Task.FromResult(ResultModel.Failed());
        }
    }
}
