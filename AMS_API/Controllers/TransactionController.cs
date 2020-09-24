using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace AMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : BaseApiController
    {
        public TransactionController(IServiceManager service, IConfiguration config) : base(service, config)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post(TransactionToSaveDto transactionToSaveDto)
        {
            int id = await _serviceManager.Transaction.Add(transactionToSaveDto);

            return Ok(id);
        }
    }
}
