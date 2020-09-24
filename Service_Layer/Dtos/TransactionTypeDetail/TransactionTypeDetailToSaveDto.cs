using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class TransactionTypeDetailToSaveDto
    {
        public int TransactionTypeId { get; set; }
        //[Required(ErrorMessage ="Account No is required.")]
        public int? AccountId { get; set; }
        [Required(ErrorMessage ="Transaction code is required.")]
        public int TranCode { get; set; }
        public bool IsActive { get; set; }
    }
}
