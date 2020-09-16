namespace Service_Layer.Dtos
{
    public class TransactionTypeDetailToEditDto
    {
        public int TransactionTypeId { get; set; }
        public int AccountId { get; set; }
        public int TranCode { get; set; }
        public bool IsActive { get; set; }
    }
}
