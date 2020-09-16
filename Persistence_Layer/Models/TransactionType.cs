using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class TransactionType : Audit
    {
        [StringLength(100)]
        public string Description { get; set; }
        public int SortId { get; set; }
    }
}
