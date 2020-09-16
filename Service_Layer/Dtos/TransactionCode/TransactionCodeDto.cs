using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class TransactionCodeDto
    {
        public int TranCode { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public bool IsDebit { get; set; }
    }
}
