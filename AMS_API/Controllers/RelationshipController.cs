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
    public class RelationshipController : BaseApiController
    {
        public RelationshipController(IServiceManager service, IConfiguration config) : base(service, config)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serviceManager.Relationship.Get());
        }
    }
}
