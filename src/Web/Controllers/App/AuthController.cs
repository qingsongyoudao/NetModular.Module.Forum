using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Auth.Web;
using NetModular.Lib.Auth.Web.Attributes;
using NetModular.Lib.Module.AspNetCore.Attributes;
using NetModular.Lib.Utils.Core.Models;
using NetModular.Module.Forum.Application.AuthService;
using NetModular.Module.Forum.Application.AuthService.ViewModels;
using NetModular.Module.Forum.Application.CategoryService;
using NetModular.Module.Forum.Application.CategoryService.ViewModels;
using NetModular.Module.Forum.Domain.Category.Models;

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
        [AllowAnonymous]
        [DisableAuditing]
        [Description("获取验证码")]
        public IResultModel VerifyCode(int length = 6)
        {
            return ResultModel.Failed();//  _ service.CreateVerifyCode(length);
        }

        [HttpPost]
        [AllowAnonymous]
        [DisableAuditing]
        [Description("登录")]
        public async Task<IResultModel> Login([FromBody]LoginModel model)
        {
            var result = await _service.Login(model);
            //if (result.Successful)
            //{
            //    var account = result.Data.Account;
            //    var loginInfo = result.Data.AuthInfo;
            //    var claims = new[]
            //    {
            //        new Claim(ClaimsName.AccountId, account.Id.ToString()),
            //        new Claim(ClaimsName.AccountName, account.Name),
            //        new Claim(ClaimsName.AccountType, model.AccountType.ToInt().ToString()),
            //        new Claim(ClaimsName.Platform, model.Platform.ToInt().ToString()),
            //        new Claim(ClaimsName.LoginTime, loginInfo.LoginTime.ToString())
            //    };

            //    return _loginHandler.Hand(claims, loginInfo.RefreshToken);
            //}
            return ResultModel.Failed(result.Msg);
        }

        [HttpGet]
        [AllowAnonymous]
        [DisableAuditing]
        [Description("刷新令牌")]
        public async Task<IResultModel> RefreshToken([BindRequired]string refreshToken)
        {
            //var result = await _service.RefreshToken(refreshToken);
            //if (result.Successful)
            //{
            //    var account = result.Data.Account;
            //    var loginInfo = result.Data.AuthInfo;
            //    var claims = new[]
            //    {
            //        new Claim(ClaimsName.AccountId, account.Id.ToString()),
            //        new Claim(ClaimsName.AccountName, account.Name),
            //        new Claim(ClaimsName.AccountType, account.Type.ToInt().ToString()),
            //        new Claim(ClaimsName.Platform, loginInfo.Platform.ToInt().ToString()),
            //        new Claim(ClaimsName.LoginTime, loginInfo.LoginTime.ToString())
            //    };

            //    return _loginHandler.Hand(claims, loginInfo.RefreshToken);
            //}

            //return ResultModel.Failed(result.Msg);
            return await Task.FromResult(ResultModel.Failed());
        }
    }
}
