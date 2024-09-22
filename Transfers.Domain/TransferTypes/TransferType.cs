using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfers.Domain.TransferTypes
{
    public class TransferType : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public TransferType(string name)
        {
            Name = name;
        }

        public void SetName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Name is empty.");
            }
            Name = name;
        }
    }
}
