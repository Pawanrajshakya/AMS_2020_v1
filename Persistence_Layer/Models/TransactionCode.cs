using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence_Layer.Models
{
    public class TransactionCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TranCode { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public bool IsDebit { get; set; }
    }
}
