using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfers.Application.CreateTransfer;
using Transfers.Application.GetTransfers;
using Transfers.Infrastructure.Repositories;
using Xunit;

namespace Transfers.Tests
{
    public class CreateTransferCommandHandlerTests : TestClassBase
    {
        private readonly CreateTransferCommandHandler _sut;

        public CreateTransferCommandHandlerTests(DatabaseFixture fixture) : base(fixture)
        {
            _sut = new CreateTransferCommandHandler(new TransferRepository(_transfersDbContext),
                new BusinessEntityRepository(_transfersDbContext),
                new PersonRepository(_transfersDbContext));
        }


        [Fact]
        public async Task HandleIsAbleToReturnCorrectData()
        {
            //arrange
            var recipientAccountNumber = "recipientAccountNumber";
            var senderFirstName = "senderFirstName";
            var senderLastName = "senderLastName";
            var senderPersonalId = "11111111111";
            var recipientName = "recipientName";
            var recipientNip = "recipientNip";
            var recipientRegon = "recipientRegon";
            var recipientAddress = "recipientAddress";
            var transferAmount = 100M;
            var transferTypeId = 1;
            var saveRecipientToAddressBox = true;

            var command = new CreateTransferCommand()
            {
                RecipientAccountNumber = recipientAccountNumber,
                RecipientAddress = recipientAddress,
                SenderFirstName = senderFirstName,
                SenderLastName = senderLastName,
                SenderPersonalId = senderPersonalId,
                RecipientName = recipientName,
                RecipientNip = recipientNip,
                RecipientRegon = recipientRegon,
                SaveRecipientToAddressBox = saveRecipientToAddressBox,
                TransferAmount = transferAmount,
                TransferTypeId = transferTypeId
            };

            //act
            await _sut.Handle(command, CancellationToken.None);

            //assert
            var person = _transfersDbContext.Persons.First(f => f.FirstName == senderFirstName && f.LastName == senderLastName && f.PersonalId == senderPersonalId);
            person.Should().NotBeNull();
            var businessEntity = _transfersDbContext.BusinessEntitys.First(f => f.Name == recipientName);
            businessEntity.Should().NotBeNull();
            var transfers = _transfersDbContext.Transfers.ToList();
            transfers.Should().HaveCount(1);
            var transfer = transfers.First();
            transfer.TransferAmount.Should().Be(transferAmount);
        }
    }
}
