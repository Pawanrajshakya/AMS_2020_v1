using AutoMapper;
using Persistence_Layer.Interfaces;
using Service_Layer.Dtos;
using Service_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class TransactionService : BaseService, ITransactionService
    {
        private readonly ITransactionTypeService TransactionTypeService;
        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper, ITransactionTypeService transactionTypeService) : base(unitOfWork, mapper)
        {
            TransactionTypeService = transactionTypeService;
        }

        public async Task<int> Add(TransactionToSaveDto entity)
        {
            /*validation*/
            var account = await _unitOfWork.Account.Get(entity.AccountId);

            if (account == null)
            {
                throw new System.Exception("Invalid account.");
            }

            return 1;
        }

        public Task<TransactionDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionDto>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, TransactionToEditDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
