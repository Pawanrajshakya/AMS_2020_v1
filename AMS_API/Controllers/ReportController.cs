using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Interface;

namespace API.Controllers
{
    //[ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ReportController : BaseApiController
    {
        public ReportController(IServiceManager service, IConfiguration config)
        : base(service, config)
        {
        }

        [HttpGet]
        [Route("{reportName}/{format}")]
        public IActionResult Get(string reportName, string format)
        {
            try
            {
                if (format.ToUpper() == "EXCEL" || format.ToUpper() == "PDF")
                {
                    var connectionString = _config.GetConnectionString("DefaultConnection");

                    var resportResult = _serviceManager.Report.Get(reportName, "Reports\\" + reportName + ".rdlc", format.ToUpper(), connectionString, "DataSet1");

                    MemoryStream stream = new MemoryStream(resportResult.Content);

                    var extension = format == "excel" ? ".xls" : ".pdf";

                    return File(stream, "application/octet-stream", reportName + "_" + DateTime.Now.ToShortTimeString() + extension);
                }
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
            return NotFound();
        }
    }
}
