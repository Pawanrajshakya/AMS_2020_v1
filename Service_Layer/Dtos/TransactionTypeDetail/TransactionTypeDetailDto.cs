namespace Service_Layer.Dtos
{
    public class TransactionTypeDetailDto
    {
        public int Id { get; set; }
        public int TransactionTypeId { get; set; }
        public int AccountId { get; set; }
        public int TranCode { get; set; }
        public bool IsActive { get; set; }
    }
}
