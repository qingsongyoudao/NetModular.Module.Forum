using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace NetModular.Module.Forum.Web.Controllers.App
{
    [Route("api/v1/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
    }
}
