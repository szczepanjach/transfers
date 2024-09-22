using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfers.Domain.Transfers
{
    public interface ITransferRepository
    {
        Task CreateTransfer(Transfer transfer, CancellationToken cancellationToken);
    }
}
