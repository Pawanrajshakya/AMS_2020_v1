using Persistence.Interfaces;
using Persistence.Repository;
using System;

namespace Persistence_Layer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Account { get; }
        IAccountHistoryRepository AccountHistory { get; }
        IAccountTypeRepository AccountType { get; }
        IBusinessRepository Business { get; }
        IClientRepository Client { get; }
        IGroupRepository Group { get; }
        IRelationshipRepository Relationship { get; }
        IRoleRepository Role { get; }
        ITransactionRepository Transaction { get; }
        ITransactionCodeRepository TransactionCode { get; }
        ITransactionTypeRepository TransactionType { get; }
        ITransactionTypeDetaiRepository TransactionTypeDetail { get; }
        IUserRepository User { get; }
        IUserHistoryRepository UserHistory { get; }
        IUserActivityRepository UserActivity { get; }
        IMenuRepository Menu { get; }
        IControlRepository Control { get; }
        IImageRepository Image { get; }

        int Complete();
    }
}