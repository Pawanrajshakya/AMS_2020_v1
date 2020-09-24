using System.Collections.Generic;

namespace Service_Layer.Dtos
{
    public class TransactionTypeToEditDto
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<TransactionTypeDetailDto> Details { get; set; }

    }
}