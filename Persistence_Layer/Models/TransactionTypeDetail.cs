using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence_Layer.Models
{
    public class TransactionTypeDetail : Audit
    {
        [ForeignKey("TransactionTypeId")]
        public TransactionType TransactionType { get; set; }
        public int TransactionTypeId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("TranCode")]
        public TransactionCode TransactionCode { get; set; }
        public int TranCode { get; set; }
    }
}
