using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfers.Domain.Transfers
{
    public class Transfer : Entity, IAggregateRoot
    {
        public string RecipientAccountNumber { get; private set; }
        public int SenderPersonId { get; set; }
        public int RecipientBusinessEntityId { get; private set; }
        public decimal TransferAmount { get; private set; }
        public int TransferTypeId { get; private set; }

        public Transfer(string recipientAccountNumber,
            int senderPersonId,
            int recipientBusinessEntityId,
            decimal transferAmount,
            int transferTypeId)
        {
            RecipientAccountNumber = recipientAccountNumber;
            SenderPersonId = senderPersonId;
            RecipientBusinessEntityId = recipientBusinessEntityId;
            TransferAmount = transferAmount;
            TransferTypeId = transferTypeId;
        }

        public void SetRecipientAccountNumber(string? recipientAccountNumber)
        {
            if (string.IsNullOrWhiteSpace(recipientAccountNumber))
            {
                throw new DomainException("RecipientAccountNumber is empty.");
            }
            RecipientAccountNumber = recipientAccountNumber;
        }

        public void SetTransferAmount(decimal transferAmount)
        {
            if (transferAmount <= 0)
            {
                throw new DomainException("TransferAmount must be greater than 0.");
            }
            TransferAmount = transferAmount;
        }

        public void SetSenderPersonId(int senderPersonId)
        {
            if (senderPersonId <= 0)
            {
                throw new DomainException("SenderPersonId must be greater than 0.");
            }
            SenderPersonId = senderPersonId;
        }

        public void SetRecipientBusinessEntityId(int recipientBusinessEntityId)
        {
            if (recipientBusinessEntityId <= 0)
            {
                throw new DomainException("RecipientBusinessEntityId must be greater than 0.");
            }
            RecipientBusinessEntityId = recipientBusinessEntityId;
        }

        public void SetTransferTypeId(int transferTypeId)
        {
            if (transferTypeId <= 0)
            {
                throw new DomainException("TransferTypeId must be greater than 0.");
            }
            TransferTypeId = transferTypeId;
        }
    }
}
