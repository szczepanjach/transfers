using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfers.Domain.Persons
{
    public class Person : Entity, IAggregateRoot
    {
        public Person(string? firstName, string? lastName, string? personalId)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetPersonalId(personalId);
        }

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? PersonalId { get; private set; }

        public void SetFirstName(string? firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new DomainException("Firts name is empty.");
            }
            FirstName = firstName;
        }

        public void SetLastName(string? lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new DomainException("Last name is empty.");
            }
            LastName = lastName;
        }

        public void SetPersonalId(string? personalId)
        {
            if (personalId?.Length != 11)
            {
                throw new DomainException("Personal id should have 11 numbers.");
            }
            PersonalId = personalId;
        }
    }
}
