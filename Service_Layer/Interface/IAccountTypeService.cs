using Service_Layer.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service_Layer.Interface
{
    public interface IAccountTypeService : 
    IDeleteService, 
    IAddService<AccountTypeToSaveDto>, 
    IUpdateService<AccountTypeToEditDto>
    {
        Task<List<AccountTypeDto>> Get();
    }
}