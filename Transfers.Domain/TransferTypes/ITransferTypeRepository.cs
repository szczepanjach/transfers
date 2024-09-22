using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfers.Domain.TransferTypes
{
    public interface ITransferTypeRepository
    {
        IEnumerable<TransferType> GetAll();
    }
}
