using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetModular.Module.Admin.Application.ConfigService;
using NetModular.Module.Admin.Domain.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace NetModular.Module.Forum.Web.Controllers.App
{
    [Description("站点")]
    public class ConfigController : BaseController
    {
        private readonly IConfigService _service;

        public ConfigController(IConfigService  service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("根据Key获取值")]
        [AllowAnonymous]
        public async Task<IResultModel> GetValue(string key, ConfigType type = ConfigType.System, string moduleCode = null)
        {
            if (key.IsNull())
                return ResultModel.Success(string.Empty);

            if (type == ConfigType.Module && moduleCode.IsNull())
                return ResultModel.Success(string.Empty);

            return await _service.GetValueByKey(key, type, moduleCode);
        }
    }
}
