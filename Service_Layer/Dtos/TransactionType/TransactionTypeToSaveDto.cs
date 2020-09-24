using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class TransactionTypeToSaveDto
    {
        public TransactionTypeToSaveDto()
        {
            Details = new List<TransactionTypeDetailToSaveDto>();
        }

        [Required(ErrorMessage ="Description is required.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<TransactionTypeDetailToSaveDto> Details { get; set; }
    }
}