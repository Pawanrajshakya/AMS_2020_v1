using Persistence.Interfaces;
using Persistence.Models;
using Persistence_Layer.Data;
using Persistence_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class ControlRepository: Repository<Control>, IControlRepository
    {
        public ControlRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
