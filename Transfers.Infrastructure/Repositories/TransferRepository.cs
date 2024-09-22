using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfers.Domain.Transfers;

namespace Transfers.Infrastructure.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransfersDbContext _context;

        public TransferRepository(TransfersDbContext context)
        {
            _context = context;
        }

        public async Task CreateTransfer(Transfer transfer, CancellationToken cancellationToken)
        {
            _context.Transfers.Add(transfer);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
