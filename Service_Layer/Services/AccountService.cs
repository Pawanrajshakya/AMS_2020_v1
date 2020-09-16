using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Service_Layer.Dtos;
using Service_Layer.Helpers;
using Service_Layer.Interface;

namespace Service_Layer.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        public async Task<int> Add(AccountToSaveDto entity)
        {
            if (await GetMainAccountId(entity.ClientId) > 0)
                throw new Exception("This client already has main account.");

            Account entityToSave = _mapper.Map<Account>(entity);

            AccountType accountType = await _unitOfWork.AccountType.Get(entity.AccountTypeId);

            if (accountType == null)
                throw new Exception("Invalid Account Type.");

            entityToSave.AccountNo = GenerateAccountNo(accountType.ShortName);
            entityToSave.CreatedBy = CurrentUser.User.Id;
            entityToSave.CreatedDate = DateTime.Now;
            entityToSave.IsActive = true;
            entityToSave.IsVisible = true;

            _unitOfWork.Account.Add(entityToSave);

            _unitOfWork.Complete();

            return entityToSave.Id;

        }

        public async Task<int> GetMainAccountId(int clientId)
        {
            var account = await this._unitOfWork.Account
                .Find(x => x.ClientId == clientId & x.IsMain & x.IsActive);

            return account == null ? 0 : account.Id;
        }

        private string GenerateAccountNo(string suffix = "")
        {
            return suffix
                + DateTime.Today.Year.ToString()
                + DateTime.Today.Month.ToString().PadLeft(2, '0')
                + DateTime.Today.Day.ToString().PadLeft(2, '0')
                + DateTime.Now.Hour.ToString().PadLeft(2, '0')
                + DateTime.Now.Minute.ToString().PadLeft(2, '0')
                + DateTime.Now.Second.ToString().PadLeft(2, '0')
                + DateTime.Now.Millisecond.ToString().PadLeft(4, '0');
        }

        public async Task<AccountDto> Get(int id)
        {
            var entity = await this._unitOfWork.Account.Get(id);

            if ((entity == null) || (!entity.IsVisible))
                return null;

            AccountDto AccountDto = _mapper.Map<AccountDto>(entity);

            return AccountDto;
        }


        public async Task<bool> Remove(int id)
        {
            var account = await this._unitOfWork.Account.Get(id);

            if (account == null)
            {
                throw new Exception("Not Found.");
            }

            this._unitOfWork.Account.Remove(account);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var Account = await this._unitOfWork.Account.Get(id);

            if (Account == null)
                throw new Exception("Not Found.");

            Account.IsVisible = false;

            this._unitOfWork.Account.Update(Account);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
        public async Task<bool> Update(int id, AccountToEditDto entity)
        {
            var account = await this._unitOfWork.Account.Get(id);

            if (account == null)
                throw new Exception("Not Found.");

            //AddHistory(account);

            account.Address1 = entity.Address1;
            account.Address2 = entity.Address2;
            account.AccountNo = entity.AccountNo;
            account.ZipCode = entity.ZipCode;
            account.State = entity.State;
            account.AccountTypeId = entity.AccountTypeId;
            account.ClientId = entity.ClientId;
            account.Email = entity.Email;
            account.FirstName = entity.FirstName;
            account.IsMain = entity.IsMain;
            account.LastName = entity.LastName;
            account.MiddleName = entity.MiddleName;
            account.RelationshipId = entity.RelationshipId;
            account.Phone = entity.Phone;
            account.SortId = entity.SortId;
            account.IsActive = entity.IsActive;

            _unitOfWork.Account.Update(account);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        private void AddHistory(Account account)
        {
            AccountHistory accountHistory = _mapper.Map<AccountHistory>(account);
            _unitOfWork.AccountHistory.Add(accountHistory);
        }

        public async Task<AccountsDto> Get(Param parameters)
        {
            PagedList<AccountDto> accountDtos = new PagedList<AccountDto>();

            var queryable = _unitOfWork.Account.GetAll()
                .Include(x => x.Client)
                .Include(x => x.Relationship)
                .Include(x => x.AccountType)
                .Where(x => x.IsVisible && x.IsActive);

            switch (parameters.SearchBy.ToLower())
            {
                case "firstname":
                    queryable = queryable.Where(x => x.FirstName.Contains(parameters.SearchText));
                    break;
                case "lastname":
                    queryable = queryable.Where(x => x.LastName.Contains(parameters.SearchText));
                    break;
                case "note":
                    queryable = queryable.Where(x => x.Note.Contains(parameters.SearchText));
                    break;
                case "phone":
                    queryable = queryable.Where(x => x.Phone.Contains(parameters.SearchText));
                    break;
                case "clientname":
                    queryable = queryable.Where(x => x.Client.Name.Contains(parameters.SearchText));
                    break;
            }

            switch (parameters.SortBy.ToLower())
            {
                case "clientname":
                    switch (parameters.SortDirection.ToLower())
                    {
                        case "desc":
                            queryable = queryable.OrderByDescending(x => x.Client.Name);
                            break;
                        case "asc":
                            queryable = queryable.OrderBy(x => x.Client.Name);
                            break;
                        default:
                            queryable = queryable.OrderByDescending(x => x.CreatedDate);
                            break;
                    }
                    break;
                case "name":
                    switch (parameters.SortDirection.ToLower())
                    {
                        case "desc":
                            queryable = queryable.OrderByDescending(x => x.FirstName);
                            break;
                        case "asc":
                            queryable = queryable.OrderBy(x => x.FirstName);
                            break;
                        default:
                            queryable = queryable.OrderByDescending(x => x.CreatedDate);
                            break;
                    }
                    break;
                case "address":
                    switch (parameters.SortDirection.ToLower())
                    {
                        case "desc":
                            queryable = queryable.OrderByDescending(x => x.Address1);
                            break;
                        case "asc":
                            queryable = queryable.OrderBy(x => x.Address1);
                            break;
                        default:
                            queryable = queryable.OrderByDescending(x => x.CreatedDate);
                            break;
                    }
                    break;
                case "balance":
                    switch (parameters.SortDirection.ToLower())
                    {
                        case "desc":
                            queryable = queryable.OrderByDescending(x => x.Balance);
                            break;
                        case "asc":
                            queryable = queryable.OrderBy(x => x.Balance);
                            break;
                        default:
                            queryable = queryable.OrderByDescending(x => x.CreatedDate);
                            break;
                    }
                    break;
                case "note":
                    switch (parameters.SortDirection.ToLower())
                    {
                        case "desc":
                            queryable = queryable.OrderByDescending(x => x.Note);
                            break;
                        case "asc":
                            queryable = queryable.OrderBy(x => x.Note);
                            break;
                        default:
                            queryable = queryable.OrderByDescending(x => x.CreatedDate);
                            break;
                    }
                    break;

                case "accounttype":
                    switch (parameters.SortDirection.ToLower())
                    {
                        case "desc":
                            queryable = queryable.OrderByDescending(x => x.AccountType.Description);
                            break;
                        case "asc":
                            queryable = queryable.OrderBy(x => x.AccountType.Description);
                            break;
                        default:
                            queryable = queryable.OrderByDescending(x => x.CreatedDate);
                            break;
                    }
                    break;

                case "relationship":
                    switch (parameters.SortDirection.ToLower())
                    {
                        case "desc":
                            queryable = queryable.OrderByDescending(x => x.Relationship.Description);
                            break;
                        case "asc":
                            queryable = queryable.OrderBy(x => x.Relationship.Description);
                            break;
                        default:
                            queryable = queryable.OrderByDescending(x => x.CreatedDate);
                            break;
                    }
                    break;
            }


            var pagedAccounts = await PagedList<Account>.CreateAsync(queryable, parameters.PageNumber, parameters.PageSize);

            if (pagedAccounts != null)
            {
                foreach (var account in pagedAccounts)
                {
                    var dto = _mapper.Map<AccountDto>(account);

                    dto.ClientName = account.Client.Name;
                    dto.AccountTypeDescription = account.AccountType.Description;
                    dto.RelationshipDescription = account.Relationship.Description;

                    accountDtos.Add(dto);
                }
            }

            AccountsDto accounts = new AccountsDto();
            accounts.Accounts = accountDtos;
            accounts.CurrentPage = pagedAccounts.CurrentPage;
            accounts.PageSize = pagedAccounts.PageSize;
            accounts.TotalCount = pagedAccounts.TotalCount;
            accounts.TotalPages = pagedAccounts.TotalPages;
            return accounts;
        }

        public List<AccountDto> Get()
        {
            List<AccountDto> AccountDtos = new List<AccountDto>();
            var Accountes = (this._unitOfWork.Account.GetAll()).Where(x => x.IsVisible);
            if (Accountes != null)
            {
                foreach (var Account in Accountes)
                {
                    AccountDtos.Add(_mapper.Map<AccountDto>(Account));
                }
            }
            return AccountDtos;
        }
    }
}