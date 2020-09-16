using AutoMapper;
using Persistence_Layer.Interfaces;
using Service_Layer.Interface;

namespace Service_Layer.Services
{
    public abstract class BaseService
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        //protected readonly IServiceManager _serviceManager;
        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            //this._serviceManager = serviceManager;
        }
    }
}