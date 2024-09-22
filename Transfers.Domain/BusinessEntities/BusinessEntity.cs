using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Transfers.Domain.BusinessEntities
{
    public class BusinessEntity : Entity, IAggregateRoot
    {
        public BusinessEntity(string name, string nip, string regon, string address)
        {
            SetName(name);
            SetANip(nip);
            SetRegon(regon);
            SetAddress(address);
        }

        public string Name { get; private set; }
        public string Nip { get; private set; }
        public string Regon { get; private set; }
        public string Address { get; private set; }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Name is empty.");
            }
            Name = name;
        }

        public void SetAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new DomainException("Address is empty.");
            }
            Address = address;
        }

        public void SetANip(string nip)
        {
            if (string.IsNullOrWhiteSpace(nip))
            {
                throw new DomainException("Nip is empty.");
            }
            Nip = nip;
        }

        public void SetRegon(string regon)
        {
            if (string.IsNullOrWhiteSpace(regon))
            {
                throw new DomainException("Regon is empty.");
            }
            Regon = regon;
        }
    }
}
