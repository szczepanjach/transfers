using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfers.Domain.Persons
{
    public interface IPersonRepository
    {
        Task<Person> GetByFirstNameAndLastName(string? senderFirstName, string? senderLastName);
        Task Create(Person person);
    }
}
