using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Interfaces;
using Service_Layer.Dtos;
using Service_Layer.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class TransactionCodeService : BaseService, ITransactionCodeService
    {
        public TransactionCodeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<TransactionCodeDto> Get(int id)
        {
            var transactionCode = await _unitOfWork.TransactionCode.Get(id);
            
            var transactionCodeDto = _mapper.Map<TransactionCodeDto>(transactionCode);
            
            return transactionCodeDto;
        }

        public async Task<List<TransactionCodeDto>> Get()
        {
            var transactionCodeDtos = new List<TransactionCodeDto>();
            
            var transactionCodes = await _unitOfWork.TransactionCode.GetAll().ToListAsync();
            
            foreach (var transactionCode in transactionCodes)
            {
                var transactionCodeDto = _mapper.Map<TransactionCodeDto>(transactionCode);
                transactionCodeDtos.Add(transactionCodeDto);
            }

            return transactionCodeDtos;
        }
    }
}
