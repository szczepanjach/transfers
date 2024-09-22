using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfers.Application.Commands;
using Transfers.Domain.BusinessEntities;
using Transfers.Domain.Persons;
using Transfers.Domain.Transfers;

namespace Transfers.Application.CreateTransfer
{
    public class CreateTransferCommandHandler : ICommandHandler<CreateTransferCommand>
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IBusinessEntityRepository _businessEntityRepository;
        private readonly IPersonRepository _personRepository;

        public CreateTransferCommandHandler(ITransferRepository transferRepository,
            IBusinessEntityRepository businessEntityRepository,
            IPersonRepository personRepository)
        {
            _transferRepository = transferRepository;
            _businessEntityRepository = businessEntityRepository;
            _personRepository = personRepository;
        }

        public async Task Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetByFirstNameAndLastName(request.SenderFirstName, request.SenderLastName);
            if (person == null)
            {
                person = new Person(request.SenderFirstName, request.SenderLastName, request.SenderPersonalId);
                await _personRepository.Create(person);
            }
            var businessEntity = await _businessEntityRepository.GetByName(request.RecipientName);
            if(businessEntity == null)
            {
                if(!request.SaveRecipientToAddressBox)
                {
                    //To trzeba obsłużyć inaczej
                    return;
                }
                businessEntity = new BusinessEntity(
                    request.RecipientName,
                    request.RecipientNip,
                    request.RecipientRegon,
                    request.RecipientAddress);
                await _businessEntityRepository.Create(businessEntity);
            }
            var transfer = new Transfer(
                request.RecipientAccountNumber,
                person.Id,
                businessEntity.Id,
                request.TransferAmount,
                request.TransferTypeId);

            await _transferRepository.CreateTransfer(transfer, cancellationToken);

        }
    }
}
