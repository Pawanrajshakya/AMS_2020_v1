using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class Client : Audit
    {
        [StringLength(200)]
        public string Name { get; set; }

        public Business Business { get; set; }
        
        public int BusinessId { get; set; }
    }
}