using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class TransactionType : Audit
    {
        public TransactionType()
        {
            TransactionTypeDetails = new List<TransactionTypeDetail>();
        }

        [StringLength(100)]
        public string Description { get; set; }
        public int SortId { get; set; }
        public ICollection<TransactionTypeDetail> TransactionTypeDetails { get; set; }
    }
}
