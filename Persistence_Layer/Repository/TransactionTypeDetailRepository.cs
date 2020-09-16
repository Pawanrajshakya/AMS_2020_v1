using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Persistence_Layer.Data;
using Persistence_Layer.Repository;

namespace Persistence.Repository
{
    public class TransactionTypeDetailRepository : Repository<TransactionTypeDetail>, ITransactionTypeDetaiRepository
    {
        public TransactionTypeDetailRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
