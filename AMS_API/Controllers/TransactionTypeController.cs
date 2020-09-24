using System.Threading.Tasks;
using API.Controllers;
using API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace AMS_API.Controllers
{
    [ServiceFilter(typeof(CustomActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class TransactionTypeController : BaseApiController
    {
        public TransactionTypeController(IServiceManager service, IConfiguration config) : base(service, config)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post(TransactionTypeToSaveDto transactionTypeToSaveDto)
        {
            var id = await _serviceManager.TransactionType.Add(transactionTypeToSaveDto);

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound();

            var transactionTypeDto = await _serviceManager.TransactionType.Get(id);

            return Ok(transactionTypeDto);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var transactionTypeDtos = await _serviceManager.TransactionType.Get();

            return Ok(transactionTypeDtos);
        }
    }
}
