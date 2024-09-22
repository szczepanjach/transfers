using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfers.Domain.BusinessEntities;
using Transfers.Domain.Persons;

namespace Transfers.Infrastructure.Repositories
{
    public class BusinessEntityRepository : IBusinessEntityRepository
    {
        private readonly TransfersDbContext _transfersDbContext;

        public BusinessEntityRepository(TransfersDbContext transfersDbContext)
        {
            _transfersDbContext = transfersDbContext;
        }

        public async Task<BusinessEntity> GetByName(string name)
        {
            return await _transfersDbContext
                .BusinessEntitys
                .FirstOrDefaultAsync(f => f.Name == name);
        }

        public async Task Create(BusinessEntity businessEntity)
        {
            _transfersDbContext.BusinessEntitys.Add(businessEntity);
            await _transfersDbContext.SaveChangesAsync();
        }
    }
}
