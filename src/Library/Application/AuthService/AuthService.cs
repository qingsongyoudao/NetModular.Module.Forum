using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NetModular.Module.Forum.Application.AuthService.ViewModels;

namespace NetModular.Module.Forum.Application.AuthService
{
    public class AuthService : IAuthService
    {
        public Task<IResultModel> Register(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IResultModel> Login(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IResultModel> ChangePassword(ChangePasswordModel model)
        {
            throw new NotImplementedException();
        }
    }
}
