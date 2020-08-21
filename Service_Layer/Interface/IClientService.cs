using Service_Layer.Dtos;
using System.Collections.Generic;

namespace Service_Layer.Interface
{
    public interface IClientService : IDeleteService, 
    IAddService<ClientToSaveDto>, 
    IUpdateService<ClientToEditDto>
    {
        List<ClientDto> SearchByName(string Name, int Top = 5);
    }
}