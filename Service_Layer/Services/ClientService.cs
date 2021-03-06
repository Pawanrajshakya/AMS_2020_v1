using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Service_Layer.Dtos;
using Service_Layer.Helpers;
using Service_Layer.Interface;

namespace Service_Layer.Services
{
    public class ClientService : BaseService, IClientService
    {
        private readonly IAccountService _AccountService;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService) 
            : base(unitOfWork, mapper)
        {
            _AccountService = accountService;
        }

        public async Task<int> Add(ClientToSaveDto entity)
        {
            if (await _unitOfWork.Client.Exists(x => x.Name == entity.Name))
            {
                throw new Exception("Already exists.");
            }

            Client Client = _mapper.Map<Client>(entity);

            Client.IsActive = true;
            Client.IsVisible = true;
            Client.BusinessId = 1;
            Client.CreatedBy = CurrentUser.User.Id;

            _unitOfWork.Client.Add(Client);

            _unitOfWork.Complete();

            return Client.Id;
        }

        public async Task<ClientDto> Get(int id)
        {
            var entity = await this._unitOfWork.Client.Get(id);
            if (!entity.IsVisible)
                return null;
            ClientDto clientDto = _mapper.Map<ClientDto>(entity);
            clientDto.MainAccountId = await _AccountService.GetMainAccountId(entity.Id);
            return clientDto;
        }

        public Task<List<ClientDto>> Get()
        {
            throw new NotImplementedException();
        }

        // public async Task<IEnumerable<ClientDto>> GetAll()
        // {
        //     List<ClientDto> ClientDtos = new List<ClientDto>();
        //     var Clients = (await this._unitOfWork.Client.GetAll()).Where(x => x.IsVisible);
        //     if (Clients != null)
        //     {
        //         foreach (var Client in Clients)
        //         {
        //             ClientDtos.Add(_mapper.Map<ClientDto>(Client));
        //         }
        //     }
        //     return ClientDtos;
        // }

        public Task<PagedList<ClientDto>> GetAll(Param parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(int id)
        {
            var entity = await this._unitOfWork.Client.Get(id);

            if (entity == null)
            {
                throw new Exception("Not Found.");
            }

            this._unitOfWork.Client.Remove(entity);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public List<ClientDto> SearchByName(string Name, int Top = 5)
        {
            try
            {
                
                List<ClientDto> clientDtos = new List<ClientDto>();

                if (string.IsNullOrWhiteSpace(Name))
                    return clientDtos;

                var clients = this._unitOfWork.Client.FindAll(x => x.Name.Contains(Name) && x.IsActive && x.IsVisible).Take(Top).OrderBy(x=>x.Name).ToList();

                foreach (var client in clients)
                {
                    var clientDto = this._mapper.Map<ClientDto>(client);
                    clientDtos.Add(clientDto);
                }

                return clientDtos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> SoftDelete(int id)
        {
            var Client = await this._unitOfWork.Client.Get(id);

            if (Client == null)
                throw new Exception("Not Found.");

            Client.IsVisible = false;

            this._unitOfWork.Client.Update(Client);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> Update(int id, ClientToEditDto entity)
        {
            var Client = await this._unitOfWork.Client.Get(id);

            if (Client == null)
                throw new Exception("Not Found.");

            Client.IsActive = entity.IsActive;
            Client.BusinessId = entity.BusinessId;

            _unitOfWork.Client.Update(Client);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
    }
}