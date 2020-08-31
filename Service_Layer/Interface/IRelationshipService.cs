using Service_Layer.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service_Layer.Interface
{
    public interface IRelationshipService : IDeleteService, 
    IAddService<RelationshipToSaveDto>, 
    IUpdateService<RelationshipToEditDto>
    {
        Task<List<RelationshipDto>> Get();
    }
}