using Service_Layer.Dtos;

namespace Service_Layer.Interface
{
    public interface ITransactionTypeService : 
        IGetService<TransactionTypeDto>,
        IAddService<TransactionTypeToSaveDto>
    {

    }
}