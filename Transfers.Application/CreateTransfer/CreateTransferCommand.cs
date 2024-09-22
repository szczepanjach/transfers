using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfers.Application.Commands;

namespace Transfers.Application.CreateTransfer
{
    public class CreateTransferCommand : ICommand
    {
        public string? RecipientAccountNumber { get; set; }
        public string? SenderFirstName { get; set; }
        public string? SenderLastName { get; set; }
        public string? SenderPersonalId { get; set; }
        public string RecipientName { get; set; }
        public string RecipientNip { get; set; }
        public string RecipientRegon { get; set; }
        public string RecipientAddress { get; set; }
        public decimal TransferAmount { get; set; }
        public int TransferTypeId { get; set; }
        public bool SaveRecipientToAddressBox { get; set; }
    }
}
