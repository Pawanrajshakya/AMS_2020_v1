using API.Controllers;
using API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Interface;
using System.Threading.Tasks;

namespace AMS_API.Controllers
{
    [ServiceFilter(typeof(CustomActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class TransactionCodeController : BaseApiController
    {
        public TransactionCodeController(IServiceManager service, IConfiguration config) : base(service, config)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var transactionCodeDtos = await _serviceManager.TransactionCode.Get();
            return Ok(transactionCodeDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var transactionCodeDto = await _serviceManager.TransactionCode.Get(id);
            return Ok(transactionCodeDto);
        }
    }
}
