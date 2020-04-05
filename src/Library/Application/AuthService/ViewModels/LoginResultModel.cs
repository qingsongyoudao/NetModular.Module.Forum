using NetModular.Module.Forum.Domain.Member;

namespace NetModular.Module.Forum.Application.AuthService
{
    public class LoginResultModel
    {
        /// <summary>
        /// 账户信息
        /// </summary>
        public MemberEntity Account { get; set; }

        /// <summary>
        /// 登录令牌
        /// </summary>
        public string Token { get; set; }

        ///// <summary>
        ///// 认证信息
        ///// </summary>
        //public AccountAuthInfoEntity AuthInfo { get; set; }
    }
}