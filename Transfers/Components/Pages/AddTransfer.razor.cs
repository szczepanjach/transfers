using MediatR;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using Transfers.Application.CreateTransfer;
using Transfers.Domain.TransferTypes;

namespace Transfers.Web.Components.Pages
{
    public partial class AddTransfer
    {
        [Inject]
        public IMediator Mediator { get; set; }
        [Inject]
        public ITransferTypeRepository TransferTypeRepository { get; set; }

        private TransferModel? _transfer = new TransferModel();
        private IEnumerable<TransferType> _transferTypes;

        protected override void OnInitialized()
        {
            _transferTypes = TransferTypeRepository.GetAll();
        }

        private async Task Create()
        {
            await Mediator.Send(new CreateTransferCommand()
            {
                RecipientAccountNumber = _transfer.RecipientAccountNumber,
                RecipientAddress = _transfer.RecipientAddress,
                RecipientName = _transfer.RecipientName,
                RecipientNip = _transfer.RecipientNip,
                RecipientRegon = _transfer.RecipientRegon,
                SaveRecipientToAddressBox = _transfer.SaveRecipientToAddressBox,
                SenderFirstName = _transfer.SenderFirstName,
                SenderLastName  = _transfer.SenderLastName,
                SenderPersonalId = _transfer.SenderPersonalId,
                TransferAmount = _transfer.TransferAmount,
                TransferTypeId = _transfer.TransferTypeId
            });
            Navigation.NavigateTo("/");
        }
    }

    public class TransferModel
    {
        [Required]
        public string? RecipientAccountNumber { get; set; }
        [Required] 
        public string? SenderFirstName { get; set; }
        [Required]
        public string? SenderLastName { get; set; }
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "NIepoprawny pesel.")]
        public string? SenderPersonalId { get; set; }
        [Required] 
        public string RecipientName { get; set; }
        [Required]
        public string RecipientNip { get; set; }
        [Required]
        public string RecipientRegon { get; set; }
        [Required]
        public string RecipientAddress { get; set; }
        [Required]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Niepoprawna kwota.")]
        [Range(0, 9999999999999999.99)]
        [DataType(DataType.Currency)]
        public decimal TransferAmount { get; set; }
        [Required]
        public int TransferTypeId { get; set; }
        public bool SaveRecipientToAddressBox { get; set; }
    }
}