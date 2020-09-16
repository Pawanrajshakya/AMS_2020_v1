using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Persistence_Layer.Interfaces;

namespace Persistence_Layer.Models
{
    public class Transaction : Audit, ITransaction
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }

        [MaxLength(200)]
        public string Description1 { get; set; }

        [MaxLength(400)]
        public string Description2 { get; set; }

        [ForeignKey("TransactionTypeId")]
        public TransactionType TransactionType { get; set; }

        public int TransactionTypeId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        
        public int AccountId { get; set; }

        [StringLength(20)]
        public string TranId { get; set; }
    }
}