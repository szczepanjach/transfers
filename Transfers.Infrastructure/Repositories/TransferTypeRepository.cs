using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfers.Domain.TransferTypes;

namespace Transfers.Infrastructure.Repositories
{
    public class TransferTypeRepository : ITransferTypeRepository
    {
        private readonly TransfersDbContext _transfersDbContext;

        public TransferTypeRepository(TransfersDbContext transfersDbContext)
        {
            _transfersDbContext = transfersDbContext;
        }

        public IEnumerable<TransferType> GetAll()
        {
            return _transfersDbContext.TransferTypes.ToList();
        }
    }
}