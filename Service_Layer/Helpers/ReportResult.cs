using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Helpers
{
    public class ReportResult
    {
        public byte[] Content { get; set; }
        public string Extension { get; set; }
        public string MediaType { get; set; }
    }
}
