using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class Group : Audit
    {
        [StringLength(100)]
        [Required]
        public string Description { get; set; }

        public int SortId { get; set; }

    }
}