using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Service_Layer.Dtos;
using Service_Layer.Helpers;
using Service_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class TransactionTypeService : BaseService, ITransactionTypeService
    {

        public TransactionTypeService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        public async Task<int> Add(TransactionTypeToSaveDto entity)
        {
            try
            {
                TransactionType transactionType = new TransactionType
                {
                    Description = entity.Description,
                    IsActive = entity.IsActive,
                    IsVisible = true,
                    SortId = 0,
                    CreatedBy = CurrentUser.User.Id,
                    CreatedDate = DateTime.Now
                };

                _unitOfWork.TransactionType.Add(transactionType);

                /*validation*/

                List<TransactionTypeDetail> transactionTypeDetails = new List<TransactionTypeDetail>();
                List<TransactionCode> transactionCodes = new List<TransactionCode>();
                TransactionCode transactionCode;

                foreach (var detail in entity.Details)
                {
                    if (detail.AccountId != null && detail.AccountId > 0)
                    {
                        var account = await _unitOfWork.Account.Get(Convert.ToInt32(detail.AccountId));

                        if (account == null)
                        {
                            throw new System.Exception("Invalid account.");
                        }
                    }

                    transactionCode = await _unitOfWork.TransactionCode.Get(detail.TranCode);

                    if (transactionCode == null)
                    {
                        throw new System.Exception("Invalid transaction code.");
                    }
                    transactionCodes.Add(transactionCode);

                    _unitOfWork.TransactionTypeDetail.Add(new TransactionTypeDetail
                    {
                        TransactionTypeId = transactionType.Id,
                        TranCode = detail.TranCode,
                        AccountId = detail.AccountId == 0 ? null : detail.AccountId,
                        IsActive = detail.IsActive,
                        IsVisible = true,
                        CreatedBy = CurrentUser.User.Id,
                        CreatedDate = DateTime.Now
                    });
                }


                var transactionCodeCount = transactionCodes.Select(x => x.IsDebit).Distinct().Count();

                if (transactionCodeCount == 1)
                {
                    throw new System.Exception("Use different transaction code.");
                }


                /*commit*/

                _unitOfWork.Complete();

                return transactionType.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<TransactionTypeDto> Get(int id)
        {

            var transactionTypes = await _unitOfWork.TransactionType.GetAll()
                .Include(x => x.TransactionTypeDetails)
                .Where(x => x.Id == id & x.IsActive)
                .Where(x => x.TransactionTypeDetails.Any(y => y.IsActive))
                .ToListAsync();

            var transactionTypeDto = new TransactionTypeDto();

            foreach (var transactionType in transactionTypes)
            {

                transactionTypeDto = _mapper.Map<TransactionTypeDto>(transactionType);

                foreach (var tansactionTypeDetail in transactionType.TransactionTypeDetails)
                {
                    transactionTypeDto.Details.Add(_mapper.Map<TransactionTypeDetailDto>(tansactionTypeDetail));
                }
            }

            return transactionTypeDto;
        }

        public async Task<List<TransactionTypeDto>> Get()
        {
            var transactionTypeDtos = new List<TransactionTypeDto>();

            var transactionTypes = await _unitOfWork.TransactionType.GetAll()
                .Include(x => x.TransactionTypeDetails)
                .Where(x => x.IsActive)
                .Where(x => x.TransactionTypeDetails.Any(y => y.IsActive))
                .ToListAsync();

            foreach (var transactionType in transactionTypes)
            {
                var transactionTypeDto = _mapper.Map<TransactionTypeDto>(transactionType);

                foreach (var tansactionTypeDetail in transactionType.TransactionTypeDetails)
                {
                    transactionTypeDto.Details.Add(_mapper.Map<TransactionTypeDetailDto>(tansactionTypeDetail));
                }

                transactionTypeDtos.Add(transactionTypeDto);
            }

            return transactionTypeDtos;
        }
    }
}
