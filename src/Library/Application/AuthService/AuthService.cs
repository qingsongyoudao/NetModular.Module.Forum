using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetModular.Lib.Cache.Abstractions;
using NetModular.Module.Forum.Application.AuthService.ViewModels;
using NetModular.Module.Forum.Domain.Member;
using NetModular.Module.Forum.Infrastructure;
using NetModular.Module.Forum.Infrastructure.PasswordHandler;
using NetModular.Module.Forum.Infrastructure.Repositories;

namespace NetModular.Module.Forum.Application.AuthService
{
    public class AuthService : IAuthService
    {
        private IMemberRepository _repository;

        private readonly IPasswordHandler _passwordHandler;
        private readonly ForumDbContext _dbContext;
        private readonly ICacheHandler _cacheHandler;

        public AuthService(IMemberRepository repository, IPasswordHandler passwordHandler,
            ICacheHandler cacheHandler,
            ForumDbContext dbContext)
        {
            _repository = repository;
            _passwordHandler = passwordHandler;
            _dbContext = dbContext;
            _cacheHandler = cacheHandler;
        }

        /// <summary>
        /// 检测密码
        /// </summary>
        private bool CheckPassword(ResultModel<LoginResultModel> result, LoginModel model, MemberEntity account)
        {
            var password = _passwordHandler.Encrypt(account.UserName, model.Password);
            if (!account.Password.Equals(password))
            {
                result.Failed("密码错误");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IResultModel> Register(RegisterModel model)
        {
            //用户名称是否存在
            var existsUserName = _repository.ExistsUserName(model.UserName);
            if (existsUserName)
            {
                return ResultModel.HasExists;
            }
            //邮箱是否存在
            var existsEmail = _repository.ExistsEmail(model.UserName);
            if (existsUserName)
            {
                return ResultModel.HasExists;
            }
            var password = _passwordHandler.Encrypt(model.UserName, model.Password);
            var entity = new MemberEntity
            {
                UserName = model.UserName,
                Email = model.Email,
                NickName = model.NickName,
                Password = model.Password,
                Sex = model.Sex
            };
            var result = await _repository.AddAsync(entity);
            return ResultModel.Result(result);
        }

        /// <summary>
        /// 会员登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IResultModel> Login(LoginModel model)
        {
            var result = new ResultModel<LoginResultModel>();

            //检测验证码
            //if (!await CheckVerifyCode(result, model))
            //    return result;

            //检测账户
            var account = await _repository.GetByUserName(model.UserName);
            var checkAccountResult = CheckAccountStatus(account);
            if (!checkAccountResult.Successful)
                return result.Failed(checkAccountResult.Msg);

            //检测密码
            if (!CheckPassword(result, model, account))
                return result;

            //生成令牌


            return result.Success(new LoginResultModel
            {
                Account = account,
                //AuthInfo = loginInfo
            });
        }

        /// <summary>
        /// 检查账号状态
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        private IResultModel CheckAccountStatus(MemberEntity member)
        {
            if (member == null || member.Deleted)
            {
                return ResultModel.Failed("账户不存在");
            }
            return ResultModel.Success();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IResultModel> ChangePassword(ChangePasswordModel model)
        {
            var memberId = _dbContext.LoginInfo.AccountId;
            var member = await _repository.GetAsync(memberId);
            var oldPassword = _passwordHandler.Encrypt(member.UserName, model.OldPassword);
            if (!oldPassword.Equals(member.Password))
            {
                return ResultModel.Failed("密码验证错误~");
            }
            var password = _passwordHandler.Encrypt(member.UserName, model.NewPassword);

            member.Password = password;
            var result = await _repository.UpdateAsync(member);
            if (!result)
            {
                return ResultModel.Failed("密码修改失败~");
            }
            return ResultModel.Success();
        }

        /// <summary>
        /// 检查邮箱是否存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<IResultModel> CheckEmail(string email)
        {
            if (_cacheHandler.TryGetValue(CacheKeys.USER_EMAIL, out List<string> root))
            {
                return ResultModel.Success(root != null && root.Contains(email));
            }
            var list = _repository.GetAll().Where(w => !string.IsNullOrEmpty(w.Email)).Select(s => s.Email).ToList();
            await _cacheHandler.SetAsync(CacheKeys.USER_EMAIL, list);
            return ResultModel.Success(root);
        }

        /// <summary>
        /// 检查账号是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<IResultModel> CheckUserName(string userName)
        {
            if (_cacheHandler.TryGetValue(CacheKeys.USER_USER_NAME, out List<string> root))
            {
                return ResultModel.Success(root != null && root.Contains(userName));
            }
            var list = _repository.GetAll().Where(w => !string.IsNullOrEmpty(w.UserName)).Select(s => s.UserName).ToList();
            await _cacheHandler.SetAsync(CacheKeys.USER_USER_NAME, list);
            return ResultModel.Success(root);
        }


    }
}
