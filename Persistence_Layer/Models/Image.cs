using Persistence_Layer.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Models
{
    public class Image: Audit
    {
        [MaxLength(1), Required]
        public string ReferneceType { get; set; }

        public int ReferenceId { get; set; }
        public byte[] Blob { get; set; }

        [MaxLength(5)]
        public string ImageType { get; set; }

        public int Size { get; set; }

        [MaxLength(400)]
        public string Comment { get; set; }


    }
}
