using System.Collections.Generic;

namespace Service_Layer.Dtos
{
    public class TransactionTypeDto
    {
        public TransactionTypeDto()
        {
            Details = new List<TransactionTypeDetailDto>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<TransactionTypeDetailDto> Details { get; set; }
    }
}