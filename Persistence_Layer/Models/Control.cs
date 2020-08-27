using Persistence_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    public class Control
    {
        public int Id { get; set; }
        public Business Business { get; set; }
        public int BusinessId { get; set; }
        public DateTime CurrentDate { get; set; }
        public int AccountNoLength { get; set; }
        public string ReportFolderName { get; set; }
    }
}
