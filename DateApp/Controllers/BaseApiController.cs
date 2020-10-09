using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateApp.UI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DateApp.UI.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        
    }
}
