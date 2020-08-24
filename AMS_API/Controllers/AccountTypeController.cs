using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Interface;

namespace API.Controllers
{
    [ServiceFilter(typeof(CustomActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountTypeController : BaseApiController
    {
        public AccountTypeController(IServiceManager service, IConfiguration config)
            : base(service, config)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_serviceManager.AccountType.Get());
        }

    }
}
