using MediatR;
using Microsoft.AspNetCore.Components;
using Transfers.Application.GetTransfers;

namespace Transfers.Web.Components.Pages
{
    public partial class TransfersList
    {
        [Inject]
        public IMediator Mediator { get; set; }

        private IEnumerable<TransferDto> _transfers;

        protected override async Task OnInitializedAsync()
        {
            _transfers = await Mediator.Send(new GetTransfersQuery());
        }

        private void AddTransfer()
        {
            Navigation.NavigateTo("/addTransfer");
        }
    }
}
