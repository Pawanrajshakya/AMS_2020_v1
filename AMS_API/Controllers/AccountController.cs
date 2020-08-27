using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Dtos;
using Service_Layer.Interface;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {

        public AccountController(IServiceManager service, IConfiguration config)
            : base(service, config)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post(AccountToSaveDto accountToSaveDto)
        {
            try
            {
                var accountId = await _serviceManager.Account.Add(accountToSaveDto);
                return Ok(accountId);
            }
            catch (System.Exception ex)
            {
                return HandleException(ex);
            }
        }

    }
}
