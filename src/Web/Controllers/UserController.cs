using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Module.AspNetCore.Attributes;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.Forum.Application.UserService;
using NetModular.Module.Forum.Application.UserService.ViewModels;
using NetModular.Module.Forum.Domain.User.Models;

namespace NetModular.Module.Forum.Web.Controllers
{
    [Description("用户信息管理")]
    public class UserController : ModuleController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("查询")]
        public Task<IResultModel> Query([FromQuery]UserQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpPost]
        [Description("添加")]
        public Task<IResultModel> Add(UserAddModel model)
        {
            return _service.Add(model);
        }

        [HttpDelete]
        [Description("删除")]
        public Task<IResultModel> Delete([BindRequired]int id)
        {
            return _service.Delete(id);
        }

        [HttpGet]
        [Description("编辑")]
        public Task<IResultModel> Edit([BindRequired]int id)
        {
            return _service.Edit(id);
        }

        [HttpPost]
        [Description("修改")]
        public Task<IResultModel> Update(UserUpdateModel model)
        {
            return _service.Update(model);
        }

        #region 前端类接口登录

        [HttpGet]
        [AllowAnonymous]
        [DisableAuditing]
        [Description("获取验证码")]
        public IResultModel VerifyCode(int length = 6)
        {
            //return _service.CreateVerifyCode(length);
            return ResultModel.NotExists;
        }

        [HttpPost]
        [AllowAnonymous]
        [DisableAuditing]
        [Description("登录")]
        public async Task<IResultModel> Login([FromBody]LoginModel model)
        {
            var result = await _service.Login(model);
            if (result.Successful)
            {
                var account = result.Data.Account;
                var loginInfo = result.Data.AuthInfo;
                var claims = new[]
                {
                    new Claim(ClaimsName.AccountId, account.Id.ToString()),
                    new Claim(ClaimsName.AccountName, account.Name),
                    new Claim(ClaimsName.AccountType, model.AccountType.ToInt().ToString()),
                    new Claim(ClaimsName.Platform, model.Platform.ToInt().ToString()),
                    new Claim(ClaimsName.LoginTime, loginInfo.LoginTime.ToString())
                };

                return _loginHandler.Hand(claims, loginInfo.RefreshToken);
            }

            return ResultModel.Failed(result.Msg);
        }

        [HttpGet]
        [AllowAnonymous]
        [DisableAuditing]
        [Description("刷新令牌")]
        public async Task<IResultModel> RefreshToken([BindRequired]string refreshToken)
        {
            var result = await _service.RefreshToken(refreshToken);
            if (result.Successful)
            {
                var account = result.Data.Account;
                var loginInfo = result.Data.AuthInfo;
                var claims = new[]
                {
                    new Claim(ClaimsName.AccountId, account.Id.ToString()),
                    new Claim(ClaimsName.AccountName, account.Name),
                    new Claim(ClaimsName.AccountType, account.Type.ToInt().ToString()),
                    new Claim(ClaimsName.Platform, loginInfo.Platform.ToInt().ToString()),
                    new Claim(ClaimsName.LoginTime, loginInfo.LoginTime.ToString())
                };

                return _loginHandler.Hand(claims, loginInfo.RefreshToken);
            }

            return ResultModel.Failed(result.Msg);
        }


        #endregion 
    }
}
