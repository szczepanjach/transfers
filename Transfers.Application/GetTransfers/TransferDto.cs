using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfers.Application.GetTransfers
{
    public class TransferDto
    {
        public string RecipientAccountNumber { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderPersonId { get; set; }
        public string RecipientName { get; set; }
        public string RecipientNIP { get; set; }
        public string RecipientRegon { get; set; }
        public string RecipientAddress { get; set; }
        public string TransferType { get; set; }
    }
}
