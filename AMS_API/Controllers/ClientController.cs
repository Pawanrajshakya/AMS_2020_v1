using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace API.Controllers
{
    [ServiceFilter(typeof(CustomActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : BaseApiController
    {

        public ClientController(IServiceManager service, IConfiguration config) 
            : base(service, config)
        {
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _serviceManager.Client.Get(id));
        }

        [HttpGet("search/{name}/{top}")]
        public IActionResult Search(string name, int top = 5)
        {
            return Ok(_serviceManager.Client.SearchByName(name, top));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClientToSaveDto clientToSaveDto)
        {
            try
            {
                var id = await _serviceManager.Client.Add(clientToSaveDto);
                return Ok(id);
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }
    }
}
