using Persistence.Interfaces;
using Persistence.Models;
using Persistence_Layer.Data;
using Persistence_Layer.Repository;

namespace Persistence.Repository
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
