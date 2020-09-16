using Service_Layer.Dtos;
using System.Threading.Tasks;

namespace Service_Layer.Interface
{
    public interface IAccountService : 
        IDeleteService, 
        IGetWithPaginationService<AccountsDto>,
        IAddService<AccountToSaveDto>, 
        IUpdateService<AccountToEditDto>,
        IGetService<AccountDto>
    {
        Task<int> GetMainAccountId(int clientId);
    }
}