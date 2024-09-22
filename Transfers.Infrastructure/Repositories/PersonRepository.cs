using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfers.Domain.Persons;

namespace Transfers.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TransfersDbContext _transfersDbContext;

        public PersonRepository(TransfersDbContext transfersDbContext)
        {
            _transfersDbContext = transfersDbContext;
        }

        public async Task Create(Person person)
        {
            _transfersDbContext.Persons.Add(person);
            await _transfersDbContext.SaveChangesAsync();
        }

        public async Task<Person> GetByFirstNameAndLastName(string? senderFirstName, string? senderLastName)
        {
            return await _transfersDbContext.Persons.FirstOrDefaultAsync(f=>f.FirstName == senderFirstName && f.LastName == senderLastName);
        }
    }
}
