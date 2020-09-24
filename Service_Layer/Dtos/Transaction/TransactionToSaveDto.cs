using System;
using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class TransactionToSaveDto
    {
        [Required(ErrorMessage = "Transaction Date is required.")]
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        [MaxLength(255, ErrorMessage = "Max description length is 255.")]
        public string Description1 { get; set; }
        [MaxLength(255, ErrorMessage = "Max description length is 255.")]
        public string Description2 { get; set; }
        [Required(ErrorMessage = "Transaction Type is required")]
        public int TransactionTypeId { get; set; }
        [Required(ErrorMessage = "Account is required")]
        public int AccountId { get; set; }
    }
}