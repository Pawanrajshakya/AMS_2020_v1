using API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Service_Layer.Dtos;
using Service_Layer.Helpers;
using Service_Layer.Interface;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ServiceFilter(typeof(CustomActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : BaseApiController
    {

        public AccountController(IServiceManager service, IConfiguration config)
            : base(service, config)
        {
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await this._serviceManager.Account.Get(id));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Param paramerters)
        {
            try
            {
                var accounts = await _serviceManager.Account.Get(paramerters);

                if (accounts != null)
                {
                    Response.AddPaginationHeader(accounts.CurrentPage,
                    accounts.PageSize,
                    accounts.TotalCount,
                    accounts.TotalPages);
                    return Ok(accounts);
                }

                return NotFound();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AccountToSaveDto accountToSaveDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    GetModalStateMessage();

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
