using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetModular.Module.Admin.Application.ConfigService;
using NetModular.Module.Admin.Domain.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using NetModular.Lib.Config.Abstractions;

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
    }
}
