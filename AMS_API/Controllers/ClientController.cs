﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Interface;

namespace AMS_API.Controllers
{
    //[ServiceFilter(typeof(CustomActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClientController : BaseApiController
    {

        public ClientController(IServiceManager service, IConfiguration config) 
            : base(service, config)
        {
        }

        [HttpGet("search/{name}/{top}")]
        public IActionResult Search(string name, int top = 5)
        {
            return Ok(_serviceManager.Client.SearchByName(name, top));
        } 
    }
}
