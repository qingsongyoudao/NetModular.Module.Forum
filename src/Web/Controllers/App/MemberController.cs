using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.Forum.Application.MemberService;
using NetModular.Module.Forum.Application.MemberService.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace NetModular.Module.Forum.Web.Controllers.App
{
    [Description("会员接口")]
    public class MemberController : BaseController
    {
        private readonly IMemberService _service;

        public MemberController(IMemberService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("获取会员信息")]
        public Task<IResultModel> GetMemberInfo([BindRequired]int id)
        {
            return _service.Edit(id);
        }
    }
}
