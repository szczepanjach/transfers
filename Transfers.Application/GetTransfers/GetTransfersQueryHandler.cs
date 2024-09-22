using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfers.Application.Data;
using Transfers.Application.Queries;

namespace Transfers.Application.GetTransfers
{
    public class GetTransfersQueryHandler : IQueryHandler<GetTransfersQuery, IEnumerable<TransferDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetTransfersQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<TransferDto>> Handle(GetTransfersQuery request, CancellationToken cancellationToken)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();
            const string sql = @"select t.RecipientAccountNumber,
	                                p.FirstName as SenderFirstName,
	                                p.LastName as SenderLastName,
	                                p.PersonalId as SenderPersonId,
	                                be.Name as RecipientName,
	                                be.Nip as RecipientNIP,
	                                be.Regon as RecipientRegon,
	                                be.Address as RecipientAddress,
	                                tt.Name as TransferType
                                from Transfers t
	                                join BusinessEntitys be on be.Id = t.RecipientBusinessEntityId
	                                join Persons p on p.Id = t.SenderPersonId
	                                join TransferTypes tt on tt.Id = t.TransferTypeId";
            var results = await connection.QueryAsync<TransferDto>(sql);
            return results.AsEnumerable();
        }
    }
}
