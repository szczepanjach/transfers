using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfers.Domain.Persons;

namespace Transfers.Domain.BusinessEntities
{
    public interface IBusinessEntityRepository
    {
        Task<BusinessEntity> GetByName(string name);
        Task Create(BusinessEntity businessEntity);
    }
}
